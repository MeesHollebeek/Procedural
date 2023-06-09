using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Color[] colors;

    public int xSize = 20;
    public int zSize = 20;

   // public float HeightX;
  //  public float HeightZ;
    public float scale;

    public float Height;

    public float minTerrainHeight;
    public float maxTerrainHeight;

    public float offsetX = 100f;
    public float offsetZ = 100f;

    public Gradient gradient;

    // Start is called before the first frame update
    void Start()
    {
        offsetZ = Random.Range(1f, 999999f);
        offsetX = Random.Range(1f, 999999f);
        scale = Random.Range(0.02f, 0.04f);

        Height = Random.Range(6f, 9f);

        mesh = new Mesh();  
        GetComponent<MeshFilter>().mesh = mesh;

        GetComponent<MeshCollider>().sharedMesh = null;
        


        StartCoroutine(CreateShape());
        
    }

    void Update()
    {
        GetComponent<MeshCollider>().sharedMesh = mesh;

        UpdateMesh();
    }

    IEnumerator CreateShape()
    {
      vertices = new Vector3[(xSize + 1) * (zSize + 1)];
       
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * scale + offsetX, z * scale + offsetZ) * Height;
                
                vertices[i] = new Vector3(x, y, z);

                if (y > maxTerrainHeight)
                    maxTerrainHeight = y;
                if (y < minTerrainHeight)
                    minTerrainHeight = y;

                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

               
            }
            vert++;
            yield return new WaitForSeconds(.0000001f);
        }

        colors = new Color[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, vertices[i].y);
                colors[i] = gradient.Evaluate(height);
                    i++;
                
            }
        }
        
    }

    void UpdateMesh ()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;

        mesh.RecalculateNormals();
    }

}

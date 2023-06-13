using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySpawnPLace : MonoBehaviour
{
    public GameObject Tree;
    public GameObject City;
    public MeshGenerator MeshScript;
    public bool placed = false;
    public bool done = false;
    public bool ReadyToSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        
        Tree.GetComponent<Transform>();
        StartCoroutine(WaitSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        Tree = GameObject.FindGameObjectWithTag("water");

        if (Tree.transform.position.y < MeshScript.Height + 0.7f && Tree.transform.position.y > MeshScript.Height - 0.7f && !done && ReadyToSpawn)
        {
            transform.position = Tree.transform.position; 
            placed = true;
        }
        else
        {
     
            Tree.tag = "wrong";
            Debug.Log("WrongItem");
        }
        if (placed)
        {
            placed = false;
            done = true;
            GameObject clone = Instantiate(City, transform.position, Quaternion.identity);
        }
    }

    public IEnumerator WaitSpawning()

    {

        yield return new WaitForSeconds(13f);
        ReadyToSpawn = true;
       
    }

}

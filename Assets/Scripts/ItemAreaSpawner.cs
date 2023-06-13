using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAreaSpawner : MonoBehaviour
{
    public GameObject itemToSpread;

    public float itemXSpread = 10;
    public float itemYSpread = 0;
    public float itemZSpread = 10;

   

    public bool over = false;
    public bool generation = true;

   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LandGeneration());
       
        
    }

    void SpreadItems()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), Random.Range(-itemYSpread, itemYSpread), Random.Range(-itemZSpread, itemZSpread)) + transform.position;
        GameObject clone = Instantiate(itemToSpread, randPosition, Quaternion.identity);
    }

    private void Update()
    {
        

        if (!over && !generation)
        {
            StartCoroutine(Spawning());
        }
    }

    public IEnumerator Spawning()

    {

        SpreadItems();
        yield return new WaitForSeconds(0.00001f);
        if (!over)
        {
            StartCoroutine(Spawning());
        }
       

    }

    public IEnumerator done()

    {

        
        yield return new WaitForSeconds(6f);
        over = true;
    }

    public IEnumerator LandGeneration()
    {
        yield return new WaitForSeconds(6f);
        StartCoroutine(done());
        generation = false;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WATERHIT : MonoBehaviour
{
    public bool Landed = false;
    public float Ypos;
    public Vector3 TreePos;



    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Ypos = transform.position.y;
        TreePos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y == 0)
        {
          Landed = true;
        }

        if (transform.position.y <= 4.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("water") && !Landed)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("wrong") && !Landed)
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("vuurtoren"))
        {
            Destroy(gameObject);
        }
    }

    
}

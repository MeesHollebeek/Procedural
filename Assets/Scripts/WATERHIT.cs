using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WATERHIT : MonoBehaviour
{
    public bool Landed = false;
   

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y == 0)
        {
          Landed = true;
        }

        if (transform.position.y <= 2)
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
    }
}

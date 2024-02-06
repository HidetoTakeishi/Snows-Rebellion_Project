using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSnowMan : MonoBehaviour
{
    Rigidbody rb;

    public GameObject body1;
    public GameObject body2;
    public GameObject body3;

    public GameObject other1;
    public GameObject other2;

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SnowBall"))
        {
            rb = body1.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb = body2.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb = body3.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb = other1.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb = other2.GetComponent<Rigidbody>();
            rb.useGravity = true;
        }
    }
}

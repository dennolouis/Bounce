using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float force = 150;
    public float spin = 30;


    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(0, 1, 0) * spin);
        rb.AddForce(new Vector3(0, 0, -1) * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

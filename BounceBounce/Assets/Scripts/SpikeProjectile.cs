using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeProjectile : MonoBehaviour
{

    public int speed = 1;
    // Start is called before the first frame update
    void Start()
    {

        transform.LookAt(FindObjectOfType<Player>().transform);

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
    }
}

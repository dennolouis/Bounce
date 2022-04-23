using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeProjectile : MonoBehaviour
{

    public int speed = 1;

    public float range = 25;

    Transform center;
    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.FindGameObjectWithTag("Center").GetComponent<Transform>();
        transform.LookAt(FindObjectOfType<Player>().transform);        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, center.position) > range)
        {
            transform.LookAt(FindObjectOfType<Player>().transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball)
        {
            //Time.timeScale = 0;
        }
    }

}

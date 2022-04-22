using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public int speed = 5;

    bool turn = false;

    // Update is called once per frame
    void Update()
    {
        if (turn)
        {
            transform.Rotate(new Vector3(0, -1, 0) * speed * Time.deltaTime); 
        }


        if (Input.GetMouseButtonDown(0))
        {
            turn = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            turn = false;
        }

    }
}

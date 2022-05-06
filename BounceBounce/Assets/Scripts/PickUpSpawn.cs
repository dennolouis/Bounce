using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawn : MonoBehaviour
{



    public GameObject pickUp;
    public int startAmount = 2;

    public float minWaitTime = 10, maxWaitTime = 60;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < startAmount - 1; i++)
        {
            SpawnGold();
        }

        GoldSpawnLoop();
    }

    void SpawnGold()
    {
        Vector3 newPos = new Vector3(Random.Range(-2, 10), transform.position.y, Random.Range(-13, 0));
        Instantiate(pickUp, newPos, Quaternion.Euler(-75, 180, 0));
    }

    void GoldSpawnLoop()
    {
        Invoke("GoldSpawnLoop", Random.Range(minWaitTime, maxWaitTime));
        SpawnGold();
    }
}

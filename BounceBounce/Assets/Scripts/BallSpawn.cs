using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{

    public GameObject[] balls;
    public int ballToSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        NewBall();
        FindObjectOfType<Ball>().ResetGold();
    }

    public void Spawn()
    {
        Invoke("NewBall", 1);
    }

    void NewBall()
    {
        Instantiate(balls[ballToSpawn], transform.position, Quaternion.identity);
        FindObjectOfType<SoundHandler>().ballSpawn.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject helper;

    public float waitTime = 20f;




     
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetNewPosition", waitTime);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        PowerUp();

        gameObject.SetActive(false);

        Invoke("SetNewPosition", waitTime);
    }

    void PowerUp()
    {
        switch(Random.Range(0, 5))
        {
            case 0:
                ScaleUp();
                break;
            case 1:
                ScaleDown();
                break;
            case 2:
                SpeedUp();
                break;
            case 3:
                SlowDown();
                break;
            case 4:
                GetHelp();
                break;
        }
    }


    void SetNewPosition()
    {
        Vector3 newPos = new Vector3(Random.Range(-2, 10), transform.position.y, Random.Range(-13, 0));
        gameObject.transform.position = newPos;
        gameObject.SetActive(true);
    }
    



    void ScaleUp()
    {
        GameObject player = FindObjectOfType<Player>().gameObject;//.transform.localScale.x *= 1.5;
        Vector3 newScale = new Vector3(player.transform.localScale.x * 2f, player.transform.localScale.y, player.transform.localScale.z);
        player.transform.localScale = newScale;
    }

    void ScaleDown()
    {
        GameObject player = FindObjectOfType<Player>().gameObject;//.transform.localScale.x *= 1.5;
        Vector3 newScale = new Vector3(player.transform.localScale.x * 0.5f, player.transform.localScale.y, player.transform.localScale.z);
        player.transform.localScale = newScale;
    }

    void SpeedUp()
    {
        FindObjectOfType<Pivot>().speed += 100;
    }

    void SlowDown()
    {
        FindObjectOfType<Pivot>().speed -= 50;
    }

    void GetHelp()
    {
        helper.SetActive(true);
    }

}

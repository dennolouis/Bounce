using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject helper;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        GetHelp();
        
        Destroy(gameObject);
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

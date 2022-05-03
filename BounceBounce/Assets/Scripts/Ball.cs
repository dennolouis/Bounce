using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float force = 150;
    public float spin = 30;


    Rigidbody rb;


    int gold = 0;


    public TextMeshProUGUI goldTMP;


    public GameObject floatingTextPrefab;

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


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AddGold(1);
        }
        if (collision.gameObject.tag == "enemy")
        {
            ShowText("-10", new Color(255, 0, 0));
            AddGold(-10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gold")
        {
            AddGold(5);
            ShowText("+5", new Color(255, 255, 255));
            Destroy(other.gameObject);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "SafeZone")
        {
            Time.timeScale = 0;
        }
    }


    void AddGold(int amount)
    {
        gold += amount;
        gold = gold < 0 ? 0 : gold; //check if gold is less than zero
        goldTMP.text = "Gold: " + gold.ToString();
    }

    void ShowText(string text, Color color)
    {
        if (floatingTextPrefab)
        {
            GameObject prefeb = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefeb.GetComponentInChildren<TextMesh>().text = text;
            prefeb.GetComponentInChildren<TextMesh>().color = color;
            Destroy(prefeb, 1f);
        }
    }


}

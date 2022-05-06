using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float force = 150;
    public float spin = 30;


    Rigidbody rb;


    static int gold = 0;


    public TextMeshProUGUI goldTMP;
    public GameObject floatingTextPrefab;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        goldTMP = GameObject.FindGameObjectWithTag("GoldTMP").GetComponent<TextMeshProUGUI>();

        rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(0, 1, 0) * spin);
        rb.AddForce(new Vector3(0, 0, 1) * force);

        player = FindObjectOfType<Player>();
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
        switch (other.gameObject.tag)
        {
            case "Gold":
                AddGold(5);
                ShowText("+5", new Color(255, 255, 255));
                Destroy(other.gameObject);
                break;
            case "Heart":
                player.UpdateLives(1);
                ShowText("+1", new Color(255, 255, 255));
                Destroy(other.gameObject);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "SafeZone")
        {
            player.UpdateLives(-1);

            if(player.lives <= 0)
            {
                FindObjectOfType<GameOver>().CalculateTotal(gold);
                Destroy(gameObject);
                return;
            }

            FindObjectOfType<BallSpawn>().Spawn();

            
            
            Destroy(gameObject, 1f);
        }
    }


    void AddGold(int amount)
    {
        gold += amount;
        gold = gold < 0 ? 0 : gold; //check if gold is less than zero
        goldTMP.text = /*"Gold: " +*/ gold.ToString();
    }

    public void ShowText(string text, Color color)
    {
        if (floatingTextPrefab)
        {
            GameObject prefeb = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefeb.GetComponentInChildren<TextMesh>().text = text;
            prefeb.GetComponentInChildren<TextMesh>().color = color;
            Destroy(prefeb, 1f);
        }
    }

    public void ResetGold()
    {
        gold = 0;
    }

}

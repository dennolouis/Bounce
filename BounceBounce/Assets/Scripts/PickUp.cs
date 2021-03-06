using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject helper;

    public float waitTime = 20f;


    string powerUpText = "";
    Color color;

    SoundHandler soundHandler;

     
    // Start is called before the first frame update
    void Start()
    {
        soundHandler = FindObjectOfType<SoundHandler>();
        Invoke("SetNewPosition", waitTime);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        PowerUp();

        Ball ball = other.gameObject.GetComponent<Ball>();

        if (ball)
        {
            ball.ShowText(powerUpText, color);
        }

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

        powerUpText = "Big";
        color = new Color(0, 255, 62);
    }

    void ScaleDown()
    {
        soundHandler.pop.Play();
        GameObject player = FindObjectOfType<Player>().gameObject;//.transform.localScale.x *= 1.5;
        Vector3 newScale = new Vector3(player.transform.localScale.x * 0.5f, player.transform.localScale.y, player.transform.localScale.z);
        player.transform.localScale = newScale;

        powerUpText = "Shink";
        color = new Color(24, 166, 157);
    }

    void SpeedUp()
    {
        soundHandler.speedUp.Play();
        FindObjectOfType<Pivot>().speed += 100;

        powerUpText = "Fast";
        color = new Color(255, 0, 244);
    }

    void SlowDown()
    {
        soundHandler.slowDown.Play();
        FindObjectOfType<Pivot>().speed -= 50;

        powerUpText = "Slow";
        color = new Color(24, 166, 228);
    }

    void GetHelp()
    {
        soundHandler.clonePowerUp.Play();
        helper.SetActive(true);

        powerUpText = "Clone";
        color = new Color(233, 239, 0);
    }

}

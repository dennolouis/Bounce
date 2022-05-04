using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform center;

    public TextMeshProUGUI livesTMP;
    
    public int lives = 1;

    private void Start()
    {
        livesTMP.text = lives.ToString();
    }

    public void UpdateLives(int change)
    {
        lives += change;
        livesTMP.text = lives.ToString();
    }


   
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(center);        
    }
}

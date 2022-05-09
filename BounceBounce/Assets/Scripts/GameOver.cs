using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject screen;

    public float delay = 0.2f;

    public TextMeshProUGUI currentTMP, earnedTMP, totalTmp;
    
    int current = 600;
    int earnedCopy, earnedCopy1;

    int newSaveValue;


    public GameObject[] hide;

    SoundHandler soundHandler;

    bool canDouble = true;
   
    private void Awake()
    {
        currentTMP.text = current.ToString();
        totalTmp.text = currentTMP.text;
        screen.SetActive(false);
    }

    private void Start()
    {
        soundHandler = FindObjectOfType<SoundHandler>();
    }

    public void CalculateTotal(int earned)
    {
        Hide();

        screen.SetActive(true);

        newSaveValue = current + earned;

        earnedCopy = earned;
        earnedCopy1 = earned;

        earnedTMP.text = "+ " + earned;

        totalTmp.text = current.ToString();

        Invoke("CalcTotalHelper", 1f);
    }

    public void DoubleGold()
    {
        earnedCopy = 0;
        current = newSaveValue;
        totalTmp.text = current.ToString();

        if(canDouble)
        {
            newSaveValue += earnedCopy1;
            canDouble = false;
            earnedCopy = earnedCopy1;
            Invoke("CalcTotalHelper", 0.5f);
        }
    }

    void CalcTotalHelper()
    {
        if (earnedCopy <= 0) return;

        current++;
        earnedCopy--;
        totalTmp.text = current.ToString();

        soundHandler.goldSound.Play();

        Invoke("CalcTotalHelper", delay);
    }


    public void Hide()
    {
        foreach(GameObject obj in hide)
        {
            obj.SetActive(false);
        }
    }

}

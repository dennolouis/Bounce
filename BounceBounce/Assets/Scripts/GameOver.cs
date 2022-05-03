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
    int earnedCopy, earnedcopy1;
   
    private void Awake()
    {
        currentTMP.text = current.ToString();
        totalTmp.text = currentTMP.text;
        screen.SetActive(false);
    }

    public void CalculateTotal(int earned)
    {
        screen.SetActive(true);

        earnedCopy = earned;

        earnedTMP.text = "+ " + earned;

        totalTmp.text = current.ToString();

        Invoke("CalcTotalHelper", 1f);
    }

    void CalcTotalHelper()
    {
        if (earnedCopy <= 0) return;

        current++;
        earnedCopy--;
        totalTmp.text = current.ToString();

        Invoke("CalcTotalHelper", delay);
    }

}

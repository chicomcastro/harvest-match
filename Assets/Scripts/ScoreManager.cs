using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTextUI;
    private int currentScore = 0;

    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreTextUI.text = "Score: " + currentScore.ToString();
    }

    public void CountScore(bool haveDeliveredRightOrder)
    {
        int deliveryScore = haveDeliveredRightOrder ? 500 : -250;
        print(deliveryScore);
        int timeScore = haveDeliveredRightOrder ? Mathf.FloorToInt(1f / TimeManager.instance.CountDeliveryTime() * 500) : 0;
        print(timeScore);
        currentScore += Mathf.FloorToInt((deliveryScore + timeScore) / 10) * 10;
        scoreTextUI.text = "Score: " + currentScore.ToString();
    }
}

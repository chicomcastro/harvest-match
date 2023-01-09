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

    public void CountScore()
    {
        currentScore += 500;
        scoreTextUI.text = "Score: " + currentScore.ToString();
    }
}

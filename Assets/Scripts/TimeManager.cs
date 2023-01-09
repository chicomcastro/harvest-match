using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timeTextUI;
    public int totalTime = 60;
    private int currentTime;

    private void Start()
    {
        StartCoroutine(CountTime());
    }

    private IEnumerator CountTime()
    {
        currentTime = totalTime;
        while(true)
        {
            yield return new WaitForSeconds(1f);
            currentTime -= 1;
            timeTextUI.text = "Time left: " + currentTime.ToString() + "s";

            if (currentTime <= 0)
            {
                GameManager.instance.GameOver();
                break;
            }
        }
    }
}

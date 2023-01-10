using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timeTextUI;
    public int totalTime = 60;
    private int currentTime;
    private float deliveryTimer = 0f;

    public static TimeManager instance;

    private void Awake()
    {
        instance = this;
    }

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

    public void StartDeliveryTimer()
    {
        deliveryTimer = Time.time;
    }

    public float CountDeliveryTime()
    {
        return Time.time - deliveryTimer;
    }
}

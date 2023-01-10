using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        player.SetActive(false);
        gameOverPanel.SetActive(true);
        // TODO count and show total score
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int currentLevel = 1;
    public GameObject[] tends;

    private readonly Dictionary<int, int> maxItemLevelMap = new Dictionary<int, int>() { { 1, 2 }, { 2, 3 } };

    private void Awake()
    {
        instance = this;
    }

    public int GetMaxItemLevelMap()
    {
        return maxItemLevelMap[currentLevel];
    }
}

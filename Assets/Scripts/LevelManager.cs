using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int currentLevel = 1;
    public GameObject[] tends;

    private readonly Dictionary<int, int> maxItemLevelMap = new Dictionary<int, int>() { { 1, 2 }, { 2, 3 } };
    private readonly Dictionary<int, int> customerDelayLevelMap = new Dictionary<int, int>() { { 1, 1 }, { 2, 1 } };

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnCustomer());
    }

    private IEnumerator SpawnCustomer()
    {
        yield return new WaitForSeconds(customerDelayLevelMap[currentLevel]);
        CustomerSpawner.instance.SpawnNewCustomer();
    }

    public int GetMaxItemLevelMap()
    {
        return maxItemLevelMap[currentLevel];
    }
}

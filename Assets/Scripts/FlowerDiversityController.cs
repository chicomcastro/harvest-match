using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerDiversityController : MonoBehaviour
{
    public Material[] flowerKinds;

    public static FlowerDiversityController instance;

    private void Awake()
    {
        instance = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlowerDiversityController : MonoBehaviour
{
    public Material[] flowerKinds;

    public static FlowerDiversityController instance;

    private List<RegisteredFlower> registeredFlowers = new List<RegisteredFlower>();

    private void Awake()
    {
        instance = this;
    }

    private void RegisterFlower(GameObject flowerObj, Color flowerColor)
    {
        registeredFlowers.Add(new RegisteredFlower(flowerObj, flowerColor));
    }

    public Material GenerateNewFlower(GameObject flowerObj)
    {
        Material selectedFlower = flowerKinds[Random.Range(0, flowerKinds.Length)];
        RegisterFlower(flowerObj, selectedFlower.color);
        return selectedFlower;
    }

    public Color[] RequestSomeAvailableFlowerKinds(int desiredFlowersQuant)
    {
        RegisteredFlower[] availableFlowers = registeredFlowers
            .Where(flower => !flower.delivered)
            .ToArray();
        Color[] availableFlowerKinds = new Color[Mathf.Min(desiredFlowersQuant, availableFlowers.Length)];

        int initialIndex = Random.Range(0, availableFlowers.Length - Mathf.Min(desiredFlowersQuant, availableFlowers.Length));
        for (
            int i = initialIndex, j = 0;
            i < initialIndex + Mathf.Min(desiredFlowersQuant, availableFlowers.Length);
            i++, j++
        )
        {
            RegisteredFlower flower = availableFlowers[i];
            Color flowerKind = flower.kind;
            availableFlowerKinds[j] = flowerKind;
        }
        return availableFlowerKinds;
    }

    public void FlowerWasHarvested(GameObject flowerObj)
    {
        RegisteredFlower registeredFlower = registeredFlowers.Find(flower => flower.obj.GetInstanceID() == flowerObj.GetInstanceID());
        if (registeredFlower == null)
        {
            Debug.LogWarning("Flower was harvested but was not registered");
            return;
        }
        registeredFlower.harvested = true;
    }

    public void MarkFlowerAsDelivered(Color flowerKind)
    {
        RegisteredFlower registeredFlower = registeredFlowers.Find(flower => flower.harvested && !flower.delivered && flower.kind == flowerKind);
        if (registeredFlower == null)
        {
            Debug.LogWarning("Flower was harvested but was not registered");
            return;
        }
        registeredFlower.delivered = true;
    }

    public bool HasAvailableFlowers()
    {
        RegisteredFlower[] availableFlowers = registeredFlowers
            .Where(flower => !flower.delivered && !flower.harvested)
            .ToArray();
        return availableFlowers.Length > 0;
    }
}

[System.Serializable]
public class RegisteredFlower
{
    public GameObject obj;
    public Color kind;
    public bool delivered = false;
    public bool harvested = false;

    public RegisteredFlower(GameObject obj, Color kind)
    {
        this.obj = obj;
        this.kind = kind;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject newPrefab;
    [SerializeField] private Transform spawnLoc;

    public void InstantiateNewObject()
    {
        Instantiate(newPrefab, spawnLoc);
    }
}

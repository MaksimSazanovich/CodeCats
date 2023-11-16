using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSpawner : SpawnerObject
{
    private void OnEnable()
    {
        Bag.Onclicked += SubtractNumbersOfObjectsSpawned;
    }

    private void OnDisable()
    {
        Bag.Onclicked -= SubtractNumbersOfObjectsSpawned;
    }
}
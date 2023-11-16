using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSpawner : SpawnerObject
{
    private void OnEnable()
    {
        Phone.OnDelete += SubtractNumbersOfObjectsSpawned;
    }

    private void OnDisable()
    {
        Phone.OnDelete -= SubtractNumbersOfObjectsSpawned;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : SpawnObject
{
    [SerializeField] private GameObject spawnObject;
    public static event Action Onclicked;
    private void OnMouseDown()
    {
        //TO DO: Animation or Effect
        Onclicked?.Invoke();
        Instantiate(spawnObject, transform.position, Quaternion.identity);  
        Destroy(gameObject);
    }
}
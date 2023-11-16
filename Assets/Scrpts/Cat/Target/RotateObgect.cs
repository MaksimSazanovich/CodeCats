using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObgect : MonoBehaviour
{
    private RotateStrategyBase strategy;
    private void Start()
    {
        strategy = new RotateStrategyOnRandomEuler();
        RotateOnRandomEuler();
    }

    private void RotateOnRandomEuler()
    {
        if (FindObjectOfType<Phone>() != null)
        {
            ChangeStrategy(new RotateStrategyToPhone());
        }
        else
        {
            ChangeStrategy(new RotateStrategyOnRandomEuler());
        }
        Invoke("RotateOnRandomEuler", 1f);
    }

    private void ChangeStrategy(RotateStrategyBase strategy)
    {
        this.strategy = strategy;
        strategy.Rotate(transform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStrategyOnRandomEuler : RotateStrategyBase
{
    public override void Rotate(Transform transform)
    {
        transform.Rotate(0, 0, Random.Range(0, 360));
    }
}
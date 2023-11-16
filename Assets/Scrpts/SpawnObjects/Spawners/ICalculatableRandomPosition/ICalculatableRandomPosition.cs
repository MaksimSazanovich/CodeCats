using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICalculatableRandomPosition 
{
    Vector3 CalculateRandomPosition(Vector3 bounds, Transform transform);
}
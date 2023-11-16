using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatableRandomPosition_PC : ICalculatableRandomPosition
{
    public Vector3 CalculateRandomPosition(Vector3 bounds, Transform transform)
    {
        return new Vector3(Random.Range(-bounds.x + 0.5f * LerpPatrolObject.offset, bounds.x - 0.5f * LerpPatrolObject.offset), bounds.y + 2 * LerpPatrolObject.offset, transform.position.z);
    }
}
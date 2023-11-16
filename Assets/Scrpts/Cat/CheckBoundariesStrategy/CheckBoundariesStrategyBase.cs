using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class CheckBoundariesStrategyBase : MonoBehaviour
{
    protected float[] lenghtOffset;
    protected int randomIndex;

    protected Vector2 screenBounds;
    protected float BoundsX;
    protected float BoundsY = 3.5f;

    public static event Action OnCollideWithBoundaries;
    public abstract void CheckBoundaries(Transform transform, LerpPatrolObject lerpPatrolObject);

    protected LerpPatrolObject lerpPatrolObject;

    protected void Start()
    {
        lerpPatrolObject = GetComponent<LerpPatrolObject>();
    }

    protected float GetRandomOffset()
    {
        lenghtOffset = new float[] { Random.Range(-LerpPatrolObject.offset, -0.1f), Random.Range(0.1f, LerpPatrolObject.offset) };
        randomIndex = Random.Range(0, lenghtOffset.Length);
        return lenghtOffset[randomIndex];
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(new Vector3(0,0,0), new Vector3(screenBounds.x - 1, screenBounds.y, 0));
    }
}
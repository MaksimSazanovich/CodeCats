using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnObject : MonoBehaviour
{
    protected Vector3 screenBounds;
    [SerializeField ] protected float fallSpeed;
    protected Collider2D collider;
    protected virtual void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        transform.DOMove(CalculateRandomPosition(), fallSpeed).SetSpeedBased().SetEase(Ease.InSine).OnComplete(() => collider.enabled = true);
    }
    protected virtual Vector3 CalculateRandomPosition()
    {
        return new Vector3(transform.position.x, Random.Range(-screenBounds.y + 1.5f * LerpPatrolObject.offset, screenBounds.y - 1.5f * LerpPatrolObject.offset), 0);
    }
}
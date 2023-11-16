using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MergeObject : MonoBehaviour, IMergeObject
{
    private int ID;
    [SerializeField] private GameObject MergedObject;
    private Transform Block1;
    private Transform Block2;

    [SerializeField] private UpAndDisappearCoinProfit profitImage;

    [SerializeField] private float Distance;
    [SerializeField] private float MergeSpeed;
    private bool canMerge;
    private bool canDetect;

    [SerializeField] private int index;

    [SerializeField] private float range;
    [SerializeField] private LayerMask mergeLayerObjects;

    private void Start()
    {
        ID = GetInstanceID();
    }

    private void FixedUpdate()
    {
        if(canDetect) Detectobject();
        MoveTowards();

    }
    public void MoveTowards()
    {
        if (canMerge)
        {
            transform.position = Vector2.MoveTowards(Block1.position, Block2.position, MergeSpeed);
            if (Vector2.Distance(Block1.position, Block2.position) < Distance)
            {
                //if (ID < Block2.gameObject.GetComponent<MergeObject>().ID) { return; }
                Destroy(Block2.gameObject.GetComponent<MergeObject>().profitImage.gameObject);
                Destroy(profitImage.gameObject);
                GameObject O = Instantiate(MergedObject, transform.position, Quaternion.identity) as GameObject;
                Destroy(Block2.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void Detectobject()
    {
        Collider2D[] collisionObjects = Physics2D.OverlapCircleAll(transform.position, range, mergeLayerObjects);
        foreach (Collider2D collisionObject in collisionObjects)
        {
            if (collisionObject.gameObject.GetComponent<MergeObject>().index == index && ID != collisionObject.gameObject.GetComponent<MergeObject>().ID)
            {
                Block1 = transform;
                Block2 = collisionObject.transform;
                canMerge = true;
                Destroy(collisionObject.gameObject.GetComponent<DragObject>());
                Destroy(GetComponent<DragObject>());
                Destroy(collisionObject.gameObject.GetComponent<LerpPatrolObject>());
                Destroy(GetComponent<LerpPatrolObject>());
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnMouseDown() => canDetect = true;
    private void OnMouseUp() => canDetect = false;
}
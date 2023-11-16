using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DragObject : MonoBehaviour
{
    private Vector2 mousePosition;
    private float offsetX, offsetY;
    private static bool mouseButtonReleased;

    //private PatrolObject patrolObject;
    private LerpPatrolObject lerpPatrolObject;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private UnityEvent onMouseDown;
    [SerializeField] private UnityEvent onMouseDrag;
    [SerializeField] private UnityEvent onMouseUp;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lerpPatrolObject = GetComponent<LerpPatrolObject>();
    }

    private void Update()
    {

    }
    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;

        //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = mousePosition;

        spriteRenderer.sortingOrder++;

        onMouseDown.Invoke();
        lerpPatrolObject.StopMove();
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);

        onMouseDrag.Invoke();
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;

        onMouseUp.Invoke();
    }

    //private void InvokeMove() => patrolObject.Invoke("Move", 0.1f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.enabled == false)
            return;

        if (transform.position.y < collision.gameObject.transform.position.y && spriteRenderer.sortingOrder == 1)
        {
            spriteRenderer.sortingOrder = 2;
        }
        else spriteRenderer.sortingOrder = 1;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.sortingOrder = 1;
    }
}
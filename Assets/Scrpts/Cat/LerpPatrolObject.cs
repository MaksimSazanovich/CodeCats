using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPatrolObject : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float speed = 1f;
    public float stopDistance = 0.1f;

    public static float offset = 1f;
    public bool IsMooving { get => isMoving; set => isMoving = value; }
    private bool isMoving = true;
    private bool isMoovingFromBorder;
    private Vector3 originalPosition;

    public Vector3 TargetPosition { get => TargetPosition; set => targetPosition = value; }
    private Vector3 targetPosition;

    private SpriteRenderer spriteRenderer;

    private CheckBoundariesStrategyBase checkBoundariesStrategy;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalPosition = transform.position;


        targetPosition = target.position;

        checkBoundariesStrategy = new CheckBoundariesStrategyPhone();

        //DebugClass.Log(screenBounds.y - offset);
        //DebugClass.Log(-screenBounds.y + offset);
    }
    private void OnEnable()
    {
        Connect.OnDesctopDevice += ChangeStrtegyToDesctop;
        Connect.OnPhoneDevice += ChangeStrtegyToPhone;
    }

    private void OnDisable()
    {
        Connect.OnDesctopDevice -= ChangeStrtegyToDesctop;
        Connect.OnPhoneDevice -= ChangeStrtegyToPhone;
    }
    void FixedUpdate()
    {
        checkBoundariesStrategy.CheckBoundaries(transform, this);
        Move();
    }

    private void Move()
    {
        if (isMoving)
        {
            if (targetPosition.x >= transform.position.x)
                spriteRenderer.flipX = false;
            else spriteRenderer.flipX = true;

            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.fixedDeltaTime);


            if (Vector3.Distance(transform.position, targetPosition) < stopDistance)
            {
                isMoving = false;
                Invoke("ChangeTarget", 0.25f);
            }
        }
    }
    public void InvokeMovement(float time)
    {
        Invoke("Move", time);
        Invoke("StartMove", time);
    }

    public void ChangeTarget()
    {
        //if (transform.position.y >= screenBounds.y - 1.5 * offset) targetPosition = new Vector3(transform.position.x + GetRandomOffset(), transform.position.y - offset, transform.position.z);
        //else if (transform.position.y < -screenBounds.y + 1.5 * offset) targetPosition = new Vector3(transform.position.x + GetRandomOffset(), transform.position.y + offset, transform.position.z);\
        /*else*/
        targetPosition = target.position;

        isMoving = true;
    }

    public void StopMove()
    {
        targetPosition = transform.position;
        isMoving = false;
        //targetPosition = new Vector3(transform.position.x + GetRandomOffset() / 2, transform.position.y + GetRandomOffset() / 2, transform.position.z);
    }
        

    public void StartMove()
    {
        isMoving = true;
    }

    private void ChangeStrategy(CheckBoundariesStrategyBase strategy)
    {
        checkBoundariesStrategy = strategy;
    }

    private void ChangeStrtegyToPhone() => ChangeStrategy(new CheckBoundariesStrategyPhone());
    private void ChangeStrtegyToDesctop() => ChangeStrategy(new CheckBoundariesStrategyPortraitDesctop());
}

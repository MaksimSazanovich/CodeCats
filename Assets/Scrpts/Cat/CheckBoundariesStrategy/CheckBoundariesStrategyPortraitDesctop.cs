using UnityEngine;

public class CheckBoundariesStrategyPortraitDesctop : CheckBoundariesStrategyBase
{
    public override void CheckBoundaries(Transform transform, LerpPatrolObject lerpPatrolObject)
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        if (transform.position.x < -screenBounds.x || transform.position.x > screenBounds.x || transform.position.y < -screenBounds.y || transform.position.y > screenBounds.y)
            lerpPatrolObject.IsMooving = false;

        if (transform.position.x < -screenBounds.x)
        {
            transform.position = new Vector2(-screenBounds.x, transform.position.y);
            lerpPatrolObject.TargetPosition = new Vector3(-screenBounds.x + LerpPatrolObject.offset, transform.position.y + GetRandomOffset(), transform.position.z);
            lerpPatrolObject.InvokeMovement(0.5f);
        }
        else if (transform.position.x > screenBounds.x)
        {
            transform.position = new Vector2(screenBounds.x, transform.position.y);
            lerpPatrolObject.TargetPosition = new Vector3(screenBounds.x - LerpPatrolObject.offset, transform.position.y + GetRandomOffset(), transform.position.z);
            lerpPatrolObject.InvokeMovement(0.5f);
        }

        if (transform.position.y < -screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, -screenBounds.y);
            lerpPatrolObject.TargetPosition = new Vector3(transform.position.x + GetRandomOffset(), -screenBounds.y + LerpPatrolObject.offset, transform.position.z);
            lerpPatrolObject.InvokeMovement(0.5f);
        }
        else if (transform.position.y > screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, screenBounds.y);
            lerpPatrolObject.TargetPosition = new Vector3(transform.position.x + GetRandomOffset(), screenBounds.y - LerpPatrolObject.offset, transform.position.z);
            lerpPatrolObject.InvokeMovement(0.5f);
        }
    }
}
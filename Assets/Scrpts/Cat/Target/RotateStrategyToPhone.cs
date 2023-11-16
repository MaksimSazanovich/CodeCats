using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStrategyToPhone : RotateStrategyBase
{
    Phone[] phones;
    Phone nearest;
    public override void Rotate(Transform transform)
    {
        phones = GameObject.FindObjectsOfType<Phone>();
        Vector3 look = transform.InverseTransformPoint(FindNearestPhone(transform).position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, angle);
    }

    private Transform FindNearestPhone(Transform transform)
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (var phone in phones)
        {
            Vector3 diff = phone.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                nearest = phone;
                distance = curDistance;
            }
        }
        return nearest.gameObject.transform;
    }
}
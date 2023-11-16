using System;
using UnityEngine;

public class Connect : MonoBehaviour
{
    public static event Action OnDesctopDevice;
    public static event Action OnPhoneDevice;
    private void Start()
    {
        if (DeviceInfo.IsMobileBrowser())
        {
            OnPhoneDevice?.Invoke();
        }
        else
        {
            OnDesctopDevice?.Invoke();
        }
    }
}
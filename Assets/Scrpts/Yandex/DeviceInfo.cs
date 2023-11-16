using UnityEngine;
using System.Runtime.InteropServices;

public class DeviceInfo : MonoBehaviour
{
#if UNITY_EDITOR || UNITY_STANDALONE
    public static bool IsMobileBrowser()
    {
        return true;
    }
#else
    [DllImport("__Internal")]
    public static extern bool IsMobileBrowser();
#endif
}
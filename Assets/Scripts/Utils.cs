using System.Runtime.InteropServices;
using UnityEngine;

public class Utils : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool _isMobile();

    public static bool IsMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
            return _isMobile();
#endif
        return false;
    }
}
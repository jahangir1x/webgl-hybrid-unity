using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Utils : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI platformText;

    private void Update()
    {
        if (IsMobile())
            platformText.text = "Mobile";
        else
            platformText.text = "Desktop";
    }

    [DllImport("__Internal")]
    private static extern bool _isMobile();

    public bool IsMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
            return _isMobile();
#endif
        return false;
    }
}
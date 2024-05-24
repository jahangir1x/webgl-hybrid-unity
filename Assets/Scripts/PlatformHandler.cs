using TMPro;
using UnityEngine;

public class PlatformHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI platformText;
    [SerializeField] private TouchController touchController;
    [SerializeField] private GameObject joystickUI;

    private void Start()
    {
        touchController.enabled = Utils.IsMobile();
        joystickUI.SetActive(Utils.IsMobile());
        platformText.text = Utils.IsMobile() ? "Mobile" : "Desktop";
    }
}
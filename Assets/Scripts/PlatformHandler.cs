using TMPro;
using UnityEngine;

public class PlatformHandler : MonoBehaviour
{
    private TouchController _touchController;
    private GameObject _joystickUI;

    private void Start()
    {
        _touchController = PlayerMovement.Instance.touchController;
        _joystickUI = CanvasHandler.Instance.gameJoystick.gameObject;
        _touchController.enabled = Utils.IsMobile();
        _joystickUI.SetActive(Utils.IsMobile());
    }
}
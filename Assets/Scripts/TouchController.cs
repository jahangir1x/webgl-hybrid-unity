using System;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    private Joystick _moveJoystick;
    public Vector2 inputVector;
    [SerializeField] private float modifier = 1f;

    private void Start()
    {
        _moveJoystick = CanvasHandler.Instance.gameJoystick;
    }

    private void Update()
    {
        if (Mathf.Abs(_moveJoystick.Horizontal) < 0.2f)
        {
            inputVector = new Vector2(0f, _moveJoystick.Vertical * modifier);
        }

        if (Mathf.Abs(_moveJoystick.Vertical) < 0.2f)
        {
            inputVector = new Vector2(_moveJoystick.Horizontal * modifier, 0f);
        }

        inputVector = new Vector2(_moveJoystick.Horizontal * modifier, _moveJoystick.Vertical * modifier);
    }
}
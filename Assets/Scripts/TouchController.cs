using StarterAssets;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Joystick moveJoystick;
    public Vector2 inputVector;
    [SerializeField] private float modifier = 1f;

    private void Update()
    {
        inputVector = new Vector2(moveJoystick.Horizontal * modifier, moveJoystick.Vertical * modifier);
    }
}
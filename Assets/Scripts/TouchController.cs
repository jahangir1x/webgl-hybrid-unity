using StarterAssets;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Joystick moveJoystick;
    public Vector2 inputVector;
    [SerializeField] private float modifier = 1f;

    private void Update()
    {
        
        if (Mathf.Abs(moveJoystick.Horizontal) < 0.2f)
        {
            inputVector = new Vector2(0f, moveJoystick.Vertical * modifier);
        }

        if (Mathf.Abs(moveJoystick.Vertical) < 0.2f)
        {
            inputVector = new Vector2(moveJoystick.Horizontal * modifier, 0f);
        }
        
        inputVector = new Vector2(moveJoystick.Horizontal * modifier, moveJoystick.Vertical * modifier);
    }
}
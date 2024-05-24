using StarterAssets;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Joystick moveJoystick;
    // [SerializeField] private FixedTouchField touchField;

    // [SerializeField] private float cameraAngleSpeed = 0.2f;

    // [SerializeField] private Vector3 cameraOffset;
    // [SerializeField] private float upAngle = 2f;
    // private float _cameraAngle;
    private StarterAssetsInputs _inputs;


    private void Awake()
    {
        _inputs = GetComponent<StarterAssetsInputs>();
    }

    private void LateUpdate()
    {
        _inputs.move = new Vector2(moveJoystick.Horizontal, moveJoystick.Vertical);

        // _inputs.look = new Vector2(touchField.TouchDist.x * Time.deltaTime * cameraAngleSpeed,
        //     -touchField.TouchDist.y * cameraAngleSpeed * Time.deltaTime);

        // _cameraAngle += touchField.TouchDist.x * cameraAngleSpeed;
        // Camera.main.transform.position =
        //     transform.position + Quaternion.AngleAxis(_cameraAngle, Vector3.up) * cameraOffset;
        // Camera.main.transform.rotation =
        //     Quaternion.LookRotation(transform.position + Vector3.up * upAngle - Camera.main.transform.position,
        //         Vector3.up);
    }
}
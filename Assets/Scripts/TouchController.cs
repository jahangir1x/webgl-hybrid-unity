using StarterAssets;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveHorizontal;
    [SerializeField] private float moveVertical;
    private StarterAssetsInputs _inputs;

    private void Awake()
    {
        _inputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        moveHorizontal = joystick.Horizontal;
        moveVertical = joystick.Vertical;

        _inputs.move = new Vector2(moveHorizontal, moveVertical);
    }
}
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator anim;
    private Transform _cam;
    private CharacterController _controller;
    [SerializeField] float speed = 9f;

    [HideInInspector] public TouchController touchController;

    float smothTime = 0.1f;
    float smothVelocity;

    public float moveVertical;
    public float moveHorizontal;
    public static PlayerMovement Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _controller = GetComponent<CharacterController>();
        touchController = GetComponent<TouchController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Camera.main != null)
        {
            _cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("Main Camera not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Utils.IsMobile())
        {
            moveVertical = touchController.inputVector.y;
            moveHorizontal = touchController.inputVector.x;
        }
        else
        {
            moveVertical = Input.GetAxis("Vertical");
            moveHorizontal = Input.GetAxis("Horizontal");
        }

        movement(moveVertical, moveHorizontal);
        animationPlay(moveVertical, moveHorizontal);
    }

    void movement(float x, float z)
    {
        Vector3 direction = new Vector3(z, 0f, x).normalized;

        if (direction.magnitude >= .1f)
        {
            float targetDirection = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - _cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetDirection, ref smothVelocity, smothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetDirection, 0f) * Vector3.forward;
            _controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    void animationPlay(float x, float z)
    {
        if (x == 0 && z == 0)
        {
            anim.Play("Idle");
            // Debug.Log("idle");
        }
        else
        {
            anim.Play("Running");
            // Debug.Log("Running");
        }
    }
}
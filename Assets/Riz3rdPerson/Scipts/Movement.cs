 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform cam;
    public Animator anim;

    public Transform feet;
    public LayerMask groundMask;

    CharacterController controller;
    
    float speed = 3f;

    float smothTime = 0.1f;
    float smothVelocity;

    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");
        
        Vector3 direction = new Vector3(z, 0f, x).normalized;

        checkForSpeed();
        if (direction.magnitude >= .1f){

            anim.Play("Running");
                
            float targetDirection = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetDirection, ref smothVelocity, smothTime);
            transform.rotation = Quaternion.Euler(0f, angle , 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetDirection, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    void checkForSpeed() {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            speed = 9f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            speed = 3f;
        }
    }
}

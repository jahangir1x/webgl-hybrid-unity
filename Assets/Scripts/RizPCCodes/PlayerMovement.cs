
using UnityEditor.Search;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    [SerializeField]
    private Transform cam;
    CharacterController controller;
    [SerializeField]
    float speed = 9f;

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
        movement(x,z);
        animationPlay(x,z);
    }
    void movement(float x , float z){
        
        
        Vector3 direction = new Vector3(z, 0f, x).normalized;

        if (direction.magnitude >= .1f){

                
            float targetDirection = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetDirection, ref smothVelocity, smothTime);
            transform.rotation = Quaternion.Euler(0f, angle , 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetDirection, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    void animationPlay(float x , float z){
        if(x == 0 && z == 0){
            anim.Play("Idle");
            Debug.Log("idle");
        }else{
            anim.Play("Running");
            Debug.Log("Running");
        }
    }
}

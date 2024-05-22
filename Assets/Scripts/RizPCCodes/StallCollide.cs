using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
public class StallCollide : MonoBehaviour
{
    PlayerInput playerInput;
    public GameObject Tray;
    bool inTrigger;
    void Start(){
        inTrigger = false;
        playerInput = GetComponent<PlayerInput>();
    }
    void OnTriggerEnter(Collider collision){
        if(collision.CompareTag("Stalls")){
            inTrigger = true;
        }
    }

    void OnTriggerExit(){
        inTrigger = false;
    }

    void Update(){
        if(inTrigger){
            ElivateTray();
        }
    }
    
    void ElivateTray(){
        if(Input.GetKey(KeyCode.F)){
            Tray.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            playerInput.enabled = false;
        }
    }


    public void DeactiveTray(){
        Tray.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerInput.enabled = true;
    }
}

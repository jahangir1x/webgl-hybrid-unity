using UnityEngine;
using System.Collections;
public class StallCollide : MonoBehaviour
{
    bool inTrigger;
    void Start(){
        inTrigger = false;
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
        if(Input.GetKey(key: KeyCode.G))
            Debug.Log("xx");
        
    }
}

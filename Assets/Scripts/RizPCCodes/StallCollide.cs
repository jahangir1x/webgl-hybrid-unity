using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEditor.Search;
using UnityEngine.UI;
public class StallCollide : MonoBehaviour
{
    [SerializeField]
    public int score;
    [SerializeField]
    Text scoreText;
    
    PlayerInput playerInput;
    [SerializeField]
    public GameObject Tray;
    bool inTrigger;
    void Start(){
        score = 0;
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

    public void CollectRightPack(){
        score += 10;
        scoreText.text = "Score: " + score.ToString();
    }

    public void CollectWrongPack(){
        score -= 5;
        scoreText.text = score.ToString();
    }
}

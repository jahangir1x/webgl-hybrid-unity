using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEditor.Search;
using UnityEngine.UI;
using UnityEditor;
public class StallCollide : MonoBehaviour
{
    [SerializeField]
    Text FinalScore;
    [SerializeField]
    GameObject panel;
    float timer;
    [SerializeField]
    public int score;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text timerText;
    
    PlayerInput playerInput;
    [SerializeField]
    public GameObject Tray;
    bool inTrigger;
    void Start(){
        score = 0;
        inTrigger = false;
        playerInput = GetComponent<PlayerInput>();
        timer = 10f;
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
        timer -= Time.deltaTime;
        timerText.text = "TimeLeft : " + timer.ToString(".00");
        if(timer <= 0f){
            turnOffAll();
        }
    }

    
    void turnOffAll(){
        timer = 0.00f;
        playerInput.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Tray.SetActive(false);
        panel.SetActive(true);
        FinalScore.text = "Total :" + score.ToString();
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
        scoreText.text = "Score: " + score.ToString();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerScoreManager : MonoBehaviour
{
    public int zincScore;
    public int ironScore;
    public int vitaminAScore;
    public int iodineScore;
    public int score;
    public float gameDuration = 12f;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI gameTimerTextUI;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private TextMeshProUGUI zincScoreUI;
    [SerializeField] private TextMeshProUGUI ironScoreUI;
    [SerializeField] private TextMeshProUGUI vitaminAScoreUI;
    [SerializeField] private TextMeshProUGUI iodineScoreUI;
    [SerializeField] private TextMeshProUGUI scoreUI;

    private void Update()
    {
        gameDuration -= Time.deltaTime;
        gameTimerTextUI.text = "Time: " + (int)gameDuration;
        if (gameDuration <= 0)
        {
            turnOffAll();
        }
    }

    private void turnOffAll()
    {
        gameDuration = 0f;
        playerMovement.enabled = false;
        gameOverPanel.SetActive(true);
        gameOverText.text = "Your Score: " + score;
    }

    public void Process(int zincScore, int ironScore, int vitaminAScore, int iodineScore)
    {
        this.zincScore += zincScore;
        this.ironScore += ironScore;
        this.vitaminAScore += vitaminAScore;
        this.iodineScore += iodineScore;
        score = this.zincScore + this.ironScore + this.vitaminAScore + this.iodineScore;

        zincScoreUI.text = this.zincScore.ToString();
        ironScoreUI.text = this.ironScore.ToString();
        vitaminAScoreUI.text = this.vitaminAScore.ToString();
        iodineScoreUI.text = this.iodineScore.ToString();
        scoreUI.text = score.ToString();
    }

    public void ReloadThisScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene()
            .name);
    }
}
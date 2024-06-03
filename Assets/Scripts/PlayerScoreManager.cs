using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerScoreManager : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    public int zincScore;
    public int ironScore;
    public int vitaminAScore;
    public int iodineScore;
    public int score;
    public float gameDuration = 12f;

    private GameObject _gameOverPanel;
    private TextMeshProUGUI _gameOverText;
    private TextMeshProUGUI _gameTimerTextUI;

    private TextMeshProUGUI _zincScoreUI;
    private TextMeshProUGUI _ironScoreUI;
    private TextMeshProUGUI _vitaminAScoreUI;
    private TextMeshProUGUI _iodineScoreUI;
    private TextMeshProUGUI _scoreUI;
    public GameObject plusUIElement;
    public GameObject minusUIElement;

    private bool _isGameStopped = false;

    public static PlayerScoreManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _playerMovement = PlayerMovement.Instance;
        _gameOverPanel = CanvasHandler.Instance.gameOverPanel;
        _gameOverText = CanvasHandler.Instance.gameOverText;
        _gameTimerTextUI = CanvasHandler.Instance.gameTimerTextUI;
        _zincScoreUI = CanvasHandler.Instance.zincScoreUI;
        _ironScoreUI = CanvasHandler.Instance.ironScoreUI;
        _vitaminAScoreUI = CanvasHandler.Instance.vitaminAScoreUI;
        _iodineScoreUI = CanvasHandler.Instance.iodineScoreUI;
        _scoreUI = CanvasHandler.Instance.scoreUI;
    }


    private void Update()
    {
        gameDuration -= Time.deltaTime;
        if (gameDuration <= 0)
        {
            gameDuration = 0;
        }

        _gameTimerTextUI.text = "Time: " + (int)gameDuration;

        if (gameDuration <= 0 && !_isGameStopped)
        {
            _isGameStopped = true;
            turnOffAll();
        }
    }

    private void turnOffAll()
    {
        gameDuration = 0f;
        _playerMovement.enabled = false;
        _gameOverPanel.SetActive(true);
        _gameOverText.text = "Your Score: " + score;
        CanvasHandler.Instance.StartVideo();
    }

    public void Process(int zincScore, int ironScore, int vitaminAScore, int iodineScore)
    {
        this.zincScore += zincScore;
        this.ironScore += ironScore;
        this.vitaminAScore += vitaminAScore;
        this.iodineScore += iodineScore;
        score = this.zincScore + this.ironScore + this.vitaminAScore + this.iodineScore;

        _zincScoreUI.text = this.zincScore.ToString();
        _ironScoreUI.text = this.ironScore.ToString();
        _vitaminAScoreUI.text = this.vitaminAScore.ToString();
        _iodineScoreUI.text = this.iodineScore.ToString();
        _scoreUI.text = score.ToString();
    }

    public void ReloadThisScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene()
            .name);
    }
}
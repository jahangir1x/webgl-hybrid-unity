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
    [SerializeField] private float totalGameDuration = 12f;
    [SerializeField] private float currentGameDuration;

    private GameObject _gameOverPanel;
    private TextMeshProUGUI _gameOverText;
    private Slider _gameTimerSlider;

    private TextMeshProUGUI _zincScoreUI;
    private TextMeshProUGUI _ironScoreUI;
    private TextMeshProUGUI _vitaminAScoreUI;
    private TextMeshProUGUI _iodineScoreUI;
    private TextMeshProUGUI _scoreUI;
    public GameObject plusUIElement;
    public GameObject minusUIElement;
    public float introDuration = 12f;
    private bool _isGameStopped = false;
    private bool _isIntroOver = false;

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
        _gameTimerSlider = CanvasHandler.Instance.gameTimerSlider;
        _zincScoreUI = CanvasHandler.Instance.zincScoreUI;
        _ironScoreUI = CanvasHandler.Instance.ironScoreUI;
        _vitaminAScoreUI = CanvasHandler.Instance.vitaminAScoreUI;
        _iodineScoreUI = CanvasHandler.Instance.iodineScoreUI;
        _scoreUI = CanvasHandler.Instance.scoreUI;

        currentGameDuration = totalGameDuration + introDuration;
    }


    private void Update()
    {
        currentGameDuration -= Time.deltaTime;
        if (currentGameDuration <= 0)
        {
            currentGameDuration = 0;
        }

        if (!_isIntroOver && currentGameDuration <= totalGameDuration)
        {
            _gameTimerSlider.gameObject.SetActive(true);
            _isIntroOver = true;
        }

        _gameTimerSlider.value = currentGameDuration / totalGameDuration;

        if (currentGameDuration <= 0 && !_isGameStopped)
        {
            _isGameStopped = true;
            turnOffAll();
        }
    }

    private void turnOffAll()
    {
        currentGameDuration = 0f;
        _playerMovement.enabled = false;
        _gameOverPanel.SetActive(true);
        CanvasHandler.Instance.gameJoystick.gameObject.SetActive(false);
        CanvasHandler.Instance.gameTimerSlider.gameObject.SetActive(false);
        CanvasHandler.Instance.trayUIObject.SetActive(false);
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
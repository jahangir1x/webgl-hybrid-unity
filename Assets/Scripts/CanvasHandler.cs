using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Video;

public class CanvasHandler : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button trayCloseButton;
    [SerializeField] private VideoPlayer endingVideoPlayer;
    public GameObject trayUIObject;
    public Transform[] trayColumns;
    public Joystick gameJoystick;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public Slider gameTimerSlider;
    public TextMeshProUGUI gameTimerText;
    public TextMeshProUGUI zincScoreUI;
    public TextMeshProUGUI ironScoreUI;
    public TextMeshProUGUI vitaminAScoreUI;
    public TextMeshProUGUI iodineScoreUI;
    public TextMeshProUGUI scoreUI;
    [SerializeField] private Button soundButton;
    private Image _soundImage;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    public static CanvasHandler Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        playAgainButton.onClick.AddListener(OnPlayAgainButtonClick);
        trayCloseButton.onClick.AddListener(OnTrayCloseButtonClick);

        _soundImage = soundButton.GetComponent<Image>();
        soundButton.onClick.AddListener(OnSoundButtonClick);
    }

    private void OnSoundButtonClick()
    {
        AudioManager.Instance.ToggleSound();
        _soundImage.sprite = AudioManager.IsSoundOn ? soundOnSprite : soundOffSprite;
    }

    private void OnTrayCloseButtonClick()
    {
        StallCollide.Instance.DeactiveTray();
    }

    private void OnPlayAgainButtonClick()
    {
        PlayerScoreManager.Instance.ReloadThisScene();
    }

    public void StartVideo()
    {
        endingVideoPlayer.Play();
    }
}
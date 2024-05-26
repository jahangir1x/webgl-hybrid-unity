using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CanvasHandler : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button TrayCloseButton;
    [SerializeField] private VideoPlayer endingVideoPlayer;
    public Transform[] trayColumns;
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
        TrayCloseButton.onClick.AddListener(OnTrayCloseButtonClick);
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
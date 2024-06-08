using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StallCollide : MonoBehaviour
{
    private TrayElementHandler _trayElementHandler;

    private GameObject _trayUI;

    private PlayerMovement _playerMovement;

    public static StallCollide Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _trayUI = CanvasHandler.Instance.trayUIObject;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        var trayElementHandler = collision.gameObject.TryGetComponent<TrayElementHandler>(out _trayElementHandler)
            ? _trayElementHandler
            : null;
        if (trayElementHandler == null) return;

        if (collision.CompareTag("Stalls") && trayElementHandler.IsTrayAvailable())
        {
            ElevateTrayUI();
        }
    }

    private void ElevateTrayUI()
    {
        AudioManager.Instance.PlayShort1();
        _trayUI.SetActive(true);
        _trayElementHandler.RandomizeElements();
        _playerMovement.anim.Play("Idle");
        _playerMovement.enabled = false;
    }


    public void DeactiveTray()
    {
        AudioManager.Instance.PlayShort2();
        _trayUI.SetActive(false);
        _playerMovement.enabled = true;
        _trayElementHandler.ResetTrayTimer();
    }
}
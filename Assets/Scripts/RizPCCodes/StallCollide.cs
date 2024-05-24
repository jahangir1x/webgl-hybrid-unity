using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StallCollide : MonoBehaviour
{
    private TrayElementHandler _trayElementHandler;

    [SerializeField] private GameObject trayUI;

    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
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
        trayUI.SetActive(true);
        _trayElementHandler.RandomizeElements();

        _playerInput.enabled = false;
    }


    public void DeactiveTray()
    {
        trayUI.SetActive(false);
        _playerInput.enabled = true;
        _trayElementHandler.ResetTrayTimer();
    }
}
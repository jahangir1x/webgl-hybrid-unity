using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StallCollide : MonoBehaviour
{
    private TrayElementHandler _trayElementHandler;

    [SerializeField] private GameObject trayUI;

    private PlayerMovement _playerMovement;

    private void Start()
    {
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
        trayUI.SetActive(true);
        _trayElementHandler.RandomizeElements();

        _playerMovement.enabled = false;
    }


    public void DeactiveTray()
    {
        trayUI.SetActive(false);
        _playerMovement.enabled = true;
        _trayElementHandler.ResetTrayTimer();
    }
}
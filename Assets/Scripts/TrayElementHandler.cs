using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TrayElementHandler : MonoBehaviour
{
    // trayColumn : [ col1, col2, col3... ]
    // col1 : [ element1, element2, element3... ]
    // element1 : [ right, wrong]
    private Transform[] _trayColumns;
    [SerializeField] private GameObject indicatorEffectObject;
    public Slider timeSlider;

    [SerializeField] private float refillDuration = 3f;
    private float _timeSinceEmptyTray = 3f;

    private void Awake()
    {
        HideIndicator();
    }

    private void Start()
    {
        _trayColumns = CanvasHandler.Instance.trayColumns;
        _timeSinceEmptyTray = refillDuration - PlayerScoreManager.Instance.introDuration;
    }

    public void Update()
    {
        _timeSinceEmptyTray += Time.deltaTime;
        if (_timeSinceEmptyTray > refillDuration)
        {
            _timeSinceEmptyTray = refillDuration;
            ShowIndicator();
        }

        timeSlider.value = _timeSinceEmptyTray / refillDuration;
    }

    private void ShowIndicator()
    {
        indicatorEffectObject.SetActive(true);
    }

    private void HideIndicator()
    {
        indicatorEffectObject.SetActive(false);
    }

    public void ResetTrayTimer()
    {
        _timeSinceEmptyTray = 0;
        HideIndicator();
    }

    public bool IsTrayAvailable()
    {
        return Mathf.Approximately(_timeSinceEmptyTray, refillDuration);
    }

    public void RandomizeElements()
    {
        // hide each element inside trayColumns 
        foreach (var column in _trayColumns)
        {
            foreach (Transform element in column.transform)
            {
                foreach (Transform child in element.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }

        // randomly set active right or wrong element in each element of trayColumns
        foreach (var column in _trayColumns)
        {
            foreach (Transform element in column.transform)
            {
                int totalElements = element.childCount;
                int randomIndex = Random.Range(0, totalElements);
                element.GetChild(randomIndex).gameObject.SetActive(true);
            }
        }
    }
}
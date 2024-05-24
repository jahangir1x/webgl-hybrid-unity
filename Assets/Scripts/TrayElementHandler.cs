using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TrayElementHandler : MonoBehaviour
{
    // trayColumn : [ col1, col2, col3... ]
    // col1 : [ element1, element2, element3... ]
    // element1 : [ right, wrong]
    [SerializeField] private Transform[] trayColumns;

    public Slider timeSlider;

    [SerializeField] private float refillDuration = 3f;
    [SerializeField] private float timeSinceEmptyTray = 3f;

    public void Update()
    {
        timeSinceEmptyTray += Time.deltaTime;
        if (timeSinceEmptyTray > refillDuration)
        {
            timeSinceEmptyTray = refillDuration;
        }

        timeSlider.value = timeSinceEmptyTray / refillDuration;
    }

    public void ResetTrayTimer()
    {
        timeSinceEmptyTray = 0;
    }

    public bool IsTrayAvailable()
    {
        return Mathf.Approximately(timeSinceEmptyTray, refillDuration);
    }

    public void RandomizeElements()
    {
        // hide each element inside trayColumns 
        foreach (var column in trayColumns)
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
        foreach (var column in trayColumns)
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
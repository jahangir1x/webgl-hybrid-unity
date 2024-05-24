using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrayElement : MonoBehaviour
{
    public int zincScore;
    public int ironScore;
    public int vitaminAScore;
    public int iodineScore;
    [SerializeField] private PlayerScoreManager playerScoreManager;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        playerScoreManager.Process(zincScore, ironScore, vitaminAScore, iodineScore);
        gameObject.SetActive(false);
    }
}
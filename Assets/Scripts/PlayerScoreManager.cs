using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    public int zincScore;
    public int ironScore;
    public int vitaminAScore;
    public int iodineScore;
    public int score;

    [SerializeField] private TextMeshProUGUI zincScoreUI;
    [SerializeField] private TextMeshProUGUI ironScoreUI;
    [SerializeField] private TextMeshProUGUI vitaminAScoreUI;
    [SerializeField] private TextMeshProUGUI iodineScoreUI;
    [SerializeField] private TextMeshProUGUI scoreUI;

    public void Process(int zincScore, int ironScore, int vitaminAScore, int iodineScore)
    {
        this.zincScore += zincScore;
        this.ironScore += ironScore;
        this.vitaminAScore += vitaminAScore;
        this.iodineScore += iodineScore;
        score = this.zincScore + this.ironScore + this.vitaminAScore + this.iodineScore;

        zincScoreUI.text = this.zincScore.ToString();
        ironScoreUI.text = this.ironScore.ToString();
        vitaminAScoreUI.text = this.vitaminAScore.ToString();
        iodineScoreUI.text = this.iodineScore.ToString();
        scoreUI.text = score.ToString();
    }
}
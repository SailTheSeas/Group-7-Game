using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int totalScore;
    [SerializeField] private TMP_Text display;



    public void UpdateScore(int scoreChange)
    {
        totalScore += scoreChange;
        display.text = totalScore.ToString();
    }

    private void Start()
    {
        totalScore = 0;
    }
}

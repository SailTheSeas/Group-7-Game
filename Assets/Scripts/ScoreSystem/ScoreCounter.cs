using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

    [SerializeField] private int totalScore;
    [SerializeField] private TMP_Text display;
    [SerializeField] private TMP_Text finishText;
    [SerializeField] private GameObject endDisplay; 
    [SerializeField] private int currentScore;

    private MouseStateManager MSM;
    public void UpdateScore(int scoreChange)
    {
        currentScore += scoreChange;
        display.text = currentScore.ToString();
    }

    private void Start()
    {
        MSM = FindObjectOfType<MouseStateManager>();
        currentScore = 0;
    }

    public void EndGame()
    {
        MSM.SetMouseState(0);
        endDisplay.SetActive(true);
        finishText.text = CalculateScore().ToString();
        Time.timeScale = 0f;
        
    }

    private int CalculateScore()
    {
        int rating = 0;
        float completion = (currentScore / (float)totalScore) * 100;       
        if (completion <= 0)
        {
            rating = 0;
        } else  if (completion > 0 && completion <= 45)
        {
            rating = 1;
        } else if (completion > 33 && completion < 80)
        {
            rating = 2;
        } else if (completion >= 80 && completion < 100)
        {
            rating = 3;
        } else if (completion >= 100)
        {
            rating = 4;
        }
        
        return rating;
    }
}

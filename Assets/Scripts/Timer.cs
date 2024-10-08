using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float totalTime;
    [SerializeField] private TMP_Text timerDisp;
    [SerializeField] private ScoreCounter SC;

    private int displayMinutes;
    private int displaySeconds;

    private void Update()
    {
        totalTime -= Time.deltaTime;
        displayMinutes = Mathf.FloorToInt(totalTime / 60);
        displaySeconds = Mathf.FloorToInt(totalTime % 60);
        if (displaySeconds > 9)
            timerDisp.text = displayMinutes.ToString() + ":" + displaySeconds.ToString();
        else
            timerDisp.text = displayMinutes.ToString() + ":0" + displaySeconds.ToString();

        if (totalTime <= 0f)
        {
            TimerEnd();
        }
    }

    private void TimerEnd()
    {
        SC.EndGame();
    }
}

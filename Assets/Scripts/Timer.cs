using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float totalTime;
    [SerializeField] private TMP_Text timerDisp;

    private int displayMinutes;
    private int displaySeconds;

    private void Update()
    {
        totalTime -= Time.deltaTime;
        displayMinutes = Mathf.FloorToInt(totalTime / 60);
        displaySeconds = Mathf.FloorToInt(totalTime % 60);
        timerDisp.text = displayMinutes.ToString() + ":" + displaySeconds.ToString();

        if (totalTime <= 0f)
        {
            TimerEnd();
        }
    }

    private void TimerEnd()
    {
        Debug.Log("Time over");
    }
}

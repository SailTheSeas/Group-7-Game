using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float totalTime;
    [SerializeField] private TMP_Text timerDisp;
    [SerializeField] private ScoreCounter SC;
    [SerializeField] private AudioClip tick;

    private AudioSource audioSource;
    private int displayMinutes;
    private int displaySeconds;
    private bool canPlaySound;
    private bool isTiming;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        canPlaySound = true;
        isTiming = false;
    }

    private void Update()
    {
        if (isTiming)
        {
            totalTime -= Time.deltaTime;
            displayMinutes = Mathf.FloorToInt(totalTime / 60);
            displaySeconds = Mathf.FloorToInt(totalTime % 60);
            if (totalTime > 100)
            {
                if (canPlaySound)
                {
                    canPlaySound = false;
                    StartCoroutine(TickTimer(totalTime / 100));
                }
            }
            else
            {
                if (totalTime > 0)
                {
                    if (canPlaySound)
                    {
                        canPlaySound = false;
                        StartCoroutine(TickTimer(1f));
                    }
                } //else if (totalTime > 30)
                /*            {
                                if (canPlaySound)
                                {
                                    canPlaySound = false;
                                    StartCoroutine(TickTimer(0.75f));
                                }
                            } else if (totalTime > 0)
                            {
                                if (canPlaySound)
                                {
                                    canPlaySound = false;
                                    StartCoroutine(TickTimer(0.65f));
                                }
                            }*/

            }

            if (displaySeconds > 9)
                timerDisp.text = displayMinutes.ToString() + ":" + displaySeconds.ToString();
            else
                timerDisp.text = displayMinutes.ToString() + ":0" + displaySeconds.ToString();

            if (totalTime <= 0f)
            {
                TimerEnd();
            }
        }
    }

    public void StartTimer()
    {
        isTiming = true;
    }

    private void TimerEnd()
    {
        SC.EndGame();
    }

    IEnumerator TickTimer(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(tick);
        canPlaySound = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stain : MonoBehaviour
{
    [SerializeField] private int maxProgress;
    [SerializeField] private int score;
    [SerializeField] private MouseState requiredType;
    [SerializeField] private AudioClip wipe;

    private AudioSource source;
    
    private MouseStateManager MSM;
    private ScoreCounter SC;

    private Progressbar progressBar;
    private float progress;
    private bool canClean, isRuined;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        progress = 0;
        isRuined = false;
        SC = FindObjectOfType<ScoreCounter>();
        MSM = FindObjectOfType<MouseStateManager>();
        progressBar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<Progressbar>();
    }

    private void OnMouseEnter()
    {
        if (MSM.GetMouseState() == MouseState.cleanMedium || MSM.GetMouseState() == MouseState.cleanWeak || MSM.GetMouseState() == MouseState.cleanStrong)
        {
            
            progressBar.SetState(true);
            progressBar.SetProgress(progress, maxProgress);
        }
    }

    private void OnMouseDown()
    {
        if (MSM.GetMouseState() == MouseState.cleanMedium || MSM.GetMouseState() == MouseState.cleanWeak || MSM.GetMouseState() == MouseState.cleanStrong)
        {
            canClean = true;
        }
    }

    private void OnMouseUp()
    {
        if (MSM.GetMouseState() == MouseState.cleanMedium || MSM.GetMouseState() == MouseState.cleanWeak || MSM.GetMouseState() == MouseState.cleanStrong)
        {
            source.Stop();
            canClean = false;
            MSM.ResetAnimator();
        }
    }

    private void OnMouseOver()
    {
        if (!isRuined)
        {
            if (canClean)
            {
                if (MSM.GetMouseState() == requiredType || (MSM.GetMouseState() >= requiredType && requiredType == MouseState.none))
                {
                    if (progress <= maxProgress)
                    {
                        if (!source.isPlaying)
                            source.PlayOneShot(wipe);
                        progress += MSM.GetRateOfCleaing() * Time.deltaTime;
                        MSM.UseDetergent();
                        progressBar.SetProgress(progress, maxProgress);
                    }
                    else
                    {
                        source.Stop();
                        MSM.ResetAnimator();
                        SC.UpdateScore(score);
                        this.gameObject.SetActive(false);
                        progressBar.SetState(false);
                    }
                }
                else
                {
                    SpriteRenderer sp = GetComponent<SpriteRenderer>();
                    sp.color = Color.black;
                    isRuined = true;
                }

            }
        }
    }

    private void OnMouseExit()
    {
        if (MSM.GetMouseState() == MouseState.cleanMedium || MSM.GetMouseState() == MouseState.cleanWeak || MSM.GetMouseState() == MouseState.cleanStrong)
        {
            progressBar.SetState(false);
        }
    }
}

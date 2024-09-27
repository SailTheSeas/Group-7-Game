using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stain : MonoBehaviour
{
    [SerializeField] private int maxProgress;
    [SerializeField] private int score;

    private ItemManager manager;
    private ScoreCounter SC;

    private Progressbar progressBar;
    private float progress;
    private bool canClean;

    private void Start()
    {
        progress = 0;
        manager = FindObjectOfType<ItemManager>();
        SC = FindObjectOfType<ScoreCounter>();
        progressBar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<Progressbar>();
    }

    private void OnMouseEnter()
    {
        if (!manager.GetHoldingState())
        {
            
            progressBar.SetState(true);
            progressBar.SetProgress(progress, maxProgress);
        }
    }

    private void OnMouseDown()
    {
        canClean = true;
    }

    private void OnMouseUp()
    {
        canClean = false;
    }

    private void OnMouseOver()
    {
        if (canClean)
        {
            if (progress <= maxProgress)
            {
                progress +=  200*Time.deltaTime;
                progressBar.SetProgress(progress, maxProgress);
            } else
            {
                SC.UpdateScore(score);
                this.gameObject.SetActive(false);
                progressBar.SetState(false);
            }
            
        }
    }

    private void OnMouseExit()
    {
        progressBar.SetState(false);
    }
}

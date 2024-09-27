using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private GameObject holder;
    
    private float progress;

    private void FixedUpdate()
    {
        progressBar.value = progress;    
    }

    public void SetProgress(float newProgress, int maxProgress)
    {
        progress = newProgress;
        progressBar.maxValue = maxProgress;
    }

    public void SetState(bool state)
    {
        holder.SetActive(state);
    }

}

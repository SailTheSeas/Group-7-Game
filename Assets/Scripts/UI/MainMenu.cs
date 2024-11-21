using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject HTP;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject LevelSelect;
    [SerializeField] private string[] levels;
    [SerializeField] private SaveData SD;
    public void LoadGame(int index)
    {
        Debug.Log("Loading");
        SceneManager.LoadSceneAsync(levels[index]);
        
    }

    public void ToggleHTP(bool state)
    {
        HTP.SetActive(state);
    }

    public void ToggleCredits(bool state)
    {
        Credits.SetActive(state);       
    }

    public void ToggleLevels(bool state)
    {
        LevelSelect.SetActive(state);
    }

    public void DeleteSave()
    {
        for (int i = 0; i < 5; i++)
        {
            SD.SetLevelScore(i, 0);
            SD.SetLevelLock(i);
        }

        SD.SetLevelUnlock(0);
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

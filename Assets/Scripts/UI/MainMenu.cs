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

    public void LoadGame(int index)
    {
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


    public void Quit()
    {
        Application.Quit();
    }
}

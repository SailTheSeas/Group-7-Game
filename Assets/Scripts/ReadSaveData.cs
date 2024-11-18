using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadSaveData : MonoBehaviour
{
    [SerializeField] private SaveData SD;
    [SerializeField] private GameObject[] levelDisplays;
    [SerializeField] private TMP_Text[] scoreDisplays;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            levelDisplays[i].SetActive(SD.GetLevelUnlock(i));
            scoreDisplays[i].text = SD.GetLevelScore(i).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

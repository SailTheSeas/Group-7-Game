using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjects/SaveData")]

public class SaveData : ScriptableObject
{
    public bool[] levelUnlocked;
    public float[] levelScore;

    public float[] GetLevelScores()
    {
        return levelScore;
    }

    public float GetLevelScore(int index)
    {
        return levelScore[index];
    }

    public bool[] GetLevelUnlocks()
    {
        return levelUnlocked;
    }

    public bool GetLevelUnlock(int index)
    {
        return levelUnlocked[index];
    }


}

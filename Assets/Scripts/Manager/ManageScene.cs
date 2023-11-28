using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ManageScenes")]
public class ManageScene : ScriptableObject
{
    [SerializeField] int totalLevels = 40;
    [SerializeField] int levelsCleared = 0;

    public void SetLevelsCleared(int clearLevel)
    {
        if (levelsCleared != totalLevels && levelsCleared < clearLevel)
        {
            levelsCleared++;
        }
    }

    public int GetLevelsCleared()
    {
        return levelsCleared;
    }

    public int GetTotalLevels()
    {
        return totalLevels;
    }

    public void LoadScenes(int levelsCleared)
    {
        this.levelsCleared = levelsCleared;
    }



}

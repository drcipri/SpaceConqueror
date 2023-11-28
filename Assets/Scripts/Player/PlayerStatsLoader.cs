using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerStatsLoader : MonoBehaviour
{
    [SerializeField] List<PlayerStats> playerStatsList;

    private void Awake()
    {
        LoadPlayerStats(playerStatsList);
    }


    public void LoadPlayerStats(List<PlayerStats> playerStatsList)
    {
        for(int listIndex = 0; listIndex < playerStatsList.Count; listIndex++)
        {
            string path = Application.persistentDataPath + "/" + playerStatsList[listIndex].name + ".cotuna";
            if (File.Exists(path))
            {
                GameData gameData = SaveSystem.LoadPlayerStats(playerStatsList[listIndex]);
                playerStatsList[listIndex].LoadStats(gameData.GetPlayerHealth(), gameData.GetBonusDamage(), gameData.GetShield(),
                      gameData.GetHealthLevel(), gameData.GetDamageLevel(), gameData.GetShieldLevel(), gameData.GetShipAquired());

            }
        }
    }
}

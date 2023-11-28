using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //crystals
    int crystals;

    //playerStats
    float playerHealth ;
    float bonusDamage ;
    float shield ;
    int upgradeHealthLevel ;
    int upgradeDamageLevel ;
    int upgradeShieldLevel ;
    bool shipAquired;

    //Scenes
    int levelsCleared;

    //FreePlay
    bool freePlay;

    //crystals
    public GameData(CrystalData crystalData)
    {
        this.crystals = crystalData.GetCrystals();

    }

    public int GetCrystals()
    {
        return crystals;
    }
    //playerStats
    public GameData(PlayerStats playerData)
    {
        this.playerHealth = playerData.GetPlayerHealth();
        this.bonusDamage = playerData.GetBonusDamage();
        this.shield = playerData.GetPlayerShield();
        this.upgradeHealthLevel = playerData.GetUpgradeHealthLevel();
        this.upgradeDamageLevel = playerData.GetUpgradeAttackLevel();
        this.upgradeShieldLevel = playerData.GetUpgradeShieldLevel();
        this.shipAquired = playerData.GetIfShipIsBought();
    }
    public bool GetShipAquired()
    {
        return shipAquired;
    }
    public float GetPlayerHealth()
    {
        return playerHealth;
    }
    public float GetBonusDamage()
    {
        return bonusDamage;
    }
    public float GetShield()
    {
        return shield;

    }
    public int GetHealthLevel()
    {
        return upgradeHealthLevel;
    }
    public int GetDamageLevel()
    {
        return upgradeDamageLevel;
    }
    public int GetShieldLevel()
    {
        return upgradeShieldLevel;
    }

    //Scenes
    public GameData(ManageScene levelsCleared)
    {
        this.levelsCleared = levelsCleared.GetLevelsCleared();

    }
    public int GetLevelsClearedGameData()
    {
        return levelsCleared;
    }

    //free play
    public GameData(FreePlay freePlay)
    {
        this.freePlay = freePlay.GetFreePlay();
    }

    public bool GetFreePlayGameData()
    {
        return freePlay;
    }

}

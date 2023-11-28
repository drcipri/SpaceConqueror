using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RestartWaveSC")]
public class RestartWaveADS : ScriptableObject
{
    int wave = 0;
    bool respawnPlayer = false;
    int playerGunUpgradeLevel = 1;

    //wave
    public void SetUpWave(int wave)
    {
        this.wave = wave - 1;
    }

    public int GetWave()
    {
        return wave;
    }

    //respawn player
    public void SetUpRespawnPlayer(bool respawnPlayer)
    {
       this.respawnPlayer = respawnPlayer;
    }

    public bool GetRespawnPlayer()
    {
        return respawnPlayer;
    }


    //player gunUpgradeLevel
    public void SetUpPlayerGunLevel(int playerGunLevel)
    {
        this.playerGunUpgradeLevel = playerGunLevel;
    }

    public int GetPlayerGunLevel()
    {
        return playerGunUpgradeLevel;
    }
}

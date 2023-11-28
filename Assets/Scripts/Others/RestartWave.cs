using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartWave : MonoBehaviour
{

    [SerializeField] RestartWaveADS restartWaveAds;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] Buttons restartLevel;

    private void Start()
    {
        SetUpTheEnemySpawnerWave();
    }

    public void RestartWaveForWatchingAds()
    {
        restartWaveAds.SetUpWave(enemySpawner.GetStartingWave());
        restartWaveAds.SetUpRespawnPlayer(true);
        restartLevel.RestartLevel();
    }

    public void SetUpTheEnemySpawnerWave()
    {
        
        if (restartWaveAds.GetRespawnPlayer() == true)
        {
            enemySpawner.SetUpStartingWave(restartWaveAds.GetWave());
            restartWaveAds.SetUpRespawnPlayer(false);
        }
       
    }
}

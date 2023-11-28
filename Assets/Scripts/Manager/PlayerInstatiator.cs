using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInstatiator : MonoBehaviour
{

    
    [SerializeField]GameObject playerInstatiateWayPoint;
    [SerializeField] PlayerChoser playerChoser;
    [SerializeField] RestartWaveADS restartWaveADS;
    UpgradePlayerGun upgradePlayerGun;


    
    

    private void Awake()
    {
        InstatiatePlayer();
        
    }


   
    private void InstatiatePlayer()
    {
     
        GameObject player = Instantiate(playerChoser.GetPlayerShip(), playerInstatiateWayPoint.transform.position, Quaternion.identity);
        if(restartWaveADS.GetRespawnPlayer() == true)
        {
            upgradePlayerGun = player.GetComponent<UpgradePlayerGun>();
            upgradePlayerGun.SetUpgradeRespawnPlayer(restartWaveADS.GetPlayerGunLevel());
            
        }
            
    }

   

}

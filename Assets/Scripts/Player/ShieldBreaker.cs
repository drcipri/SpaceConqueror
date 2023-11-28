using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBreaker : MonoBehaviour
{
    float shieldbreakerDamage;
    PlayerLaser playerLaser;
    int hitEnemy = 0;
    int enemyHitTimes = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerLaser = GetComponent<PlayerLaser>();
        
    }
    private void Update()
    {
        EnemyHit();
    }



    private void EnemyHit()
    {
        if(hitEnemy > enemyHitTimes)
        {
            shieldbreakerDamage = playerLaser.GetLaserDamage();
            playerLaser.SetDamageForShieldBreaker(shieldbreakerDamage / 2);
            enemyHitTimes = hitEnemy;
        }
    }
    public void SetEnemyHits()
    {
        hitEnemy++;
    }


}

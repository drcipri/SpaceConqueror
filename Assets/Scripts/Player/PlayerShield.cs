using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    PlayerStatus playerStatus;
    float shieldLife;
    float respawnShield;

    [Header("SFX")]
    [SerializeField] SFX sounds;
    [SerializeField] [Range(0,1)]float soundsVolume = 0.4f;

    private void Awake()
    {
        playerStatus = GetComponentInParent<PlayerStatus>();
        shieldLife = playerStatus.GetPlayerStatsShield();
        respawnShield = playerStatus.GetPlayerStatsShield();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyLaser")
        {
            AudioSource.PlayClipAtPoint(sounds.GetLaserImpact(), Camera.main.transform.position, soundsVolume);
            EnemyLaser enemyLaser = collision.GetComponent<EnemyLaser>();
            ShieldWork(enemyLaser);
        }
    }

    private void ShieldWork(EnemyLaser enemyLaser)
    {
        enemyLaser.Hit();
        shieldLife -= enemyLaser.GetEnemyLaser();
        if(shieldLife <= 0)
        {
            AudioSource.PlayClipAtPoint(sounds.GetShieldDown(), Camera.main.transform.position, soundsVolume);
            gameObject.SetActive(false);
            shieldLife = respawnShield;
        }
        
    }

    public void SetShieldLife(float addLife)
    {
        this.shieldLife = addLife;
    }
    public float GetShield()
    {
        return shieldLife;
    }
    public float GetRespawnShield()
    {
        return respawnShield;
    }
}

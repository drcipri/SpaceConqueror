using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossshield : MonoBehaviour
{
    [SerializeField]EnemyBossStats bossStats;
    [SerializeField]float shieldLife;
    [Header("Volume")]
    [SerializeField] SFX sound;
    [SerializeField] [Range(0, 1)] float soundsVolume = 0.4f;


    private void Awake()
    {
        if(bossStats.GetShieldActive() == false)
        {
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shieldLife = bossStats.GetBossShieldLife();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerLaser")
        {
            AudioSource.PlayClipAtPoint(sound.GetLaserImpact(), Camera.main.transform.position, soundsVolume);
            PlayerLaser playerLaser = collision.GetComponent<PlayerLaser>();
            ShieldWork(playerLaser);

        }
        else if (collision.tag == "BombRain")
        {
            PlayerRocket playerRocket = collision.GetComponent<PlayerRocket>();
            DamageShield(playerRocket.GetBombDamage());
            playerRocket.DestroyThisObject();
        }
    }



    private void ShieldWork(PlayerLaser playerLaser)
    {
        playerLaser.Hit();
        shieldLife -= playerLaser.GetLaserDamage();
        if(shieldLife <= 0)
        {
            AudioSource.PlayClipAtPoint(sound.GetShieldDown(), Camera.main.transform.position, soundsVolume);
            gameObject.SetActive(false);
        }


    }

    public void EnemyShieldHit(PlayerLaser laserDamage)
    {
        shieldLife -= laserDamage.GetLaserDamage();
        if (shieldLife <= 0)
        {
            AudioSource.PlayClipAtPoint(sound.GetShieldDown(), Camera.main.transform.position, soundsVolume);
            gameObject.SetActive(false);
        }
    }

    public void DamageShield(float damage)
    {
        this.shieldLife -= damage;
        if (shieldLife <= 0)
        {
            AudioSource.PlayClipAtPoint(sound.GetShieldDown(), Camera.main.transform.position, soundsVolume);
            gameObject.SetActive(false);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeGun : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float explosionRadius = 1f;
    PlayerLaser playerDamage;

    [Header("Visual and Sounds")]
    [SerializeField] GameObject flameEffect;
    [SerializeField] SFX soundEffects;
    [SerializeField] [Range(0,1)]float grenadeExplosionSound = 0.25f;
    [SerializeField] [Range(0, 1)] float zapExplosionSound = 0.25f;
    


    private void Start()
    {
        playerDamage = GetComponent<PlayerLaser>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SmallEnemy")
        {
            Grenade();
        }
        else if(collision.tag == "EnemyShield")
        {
            Grenade();
        }
    }


    public void Grenade()
    {

        Collider2D[] explosion = Physics2D.OverlapCircleAll(transform.position,explosionRadius);
        if (gameObject.name == "PlayerLaser3(Clone)")
        {
            AudioSource.PlayClipAtPoint(soundEffects.GetGrenadeGunExplosion(), Camera.main.transform.position, grenadeExplosionSound);
        }
        else if (gameObject.name == "PlayerLaser6(Clone)")
        {
            AudioSource.PlayClipAtPoint(soundEffects.GetZapGunExplosion(), Camera.main.transform.position, zapExplosionSound);
        }
        else
        {
            AudioSource.PlayClipAtPoint(soundEffects.GetRocketExplosion(), Camera.main.transform.position, grenadeExplosionSound);
        }

        foreach (Collider2D objectsFound in explosion)
        {
            if (objectsFound.TryGetComponent<EnemyStatus>(out EnemyStatus enemy))
            {
                
                //the explosion damage will be the gun set damage divided by 2f 
                enemy.DamageEnemy(playerDamage.GetLaserDamage() / 2f);
                Vector2 flamePos = new Vector2(enemy.transform.position.x, enemy.transform.position.y + 0.5f);
                if (gameObject.name == "PlayerLaser3")
                {
                    GameObject flame = Instantiate(flameEffect, flamePos, Quaternion.identity);
                    Destroy(flame, 2f);
                }
                else
                {
                    GameObject flame = Instantiate(flameEffect, enemy.transform.position, Quaternion.identity);
                    Destroy(flame, 2f);
                }
                
                
                
            }
        }
       
    }

 

  
}

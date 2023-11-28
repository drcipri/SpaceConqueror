using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{

    //health status
    [Header("Health Status")]
    [SerializeField] BossEnemyHealthbar healthbar;
    [SerializeField] float enemyHealth = 500f;
    float enemyHealthCopy;

    [Header("Crystal")]
    Crystals crystal;
    [SerializeField] int crystalValue = 30;

    
    

    [Header("Shooting Status")]
    //shooting status
    [SerializeField] GameObject enemyBullet;
    [SerializeField] float laserSpawnTime = 0.5f;
    [SerializeField] bool fire = true;
    [SerializeField] float shootingLaserChance = 0.5f;
    float randomShot;

    //Animation
    [SerializeField] GameObject enemyDeathAnimation;
    


    //Enemy  SFX
    [Header("SFX Enemy Status")]
    [SerializeField] SFX enemyDeathSFX;
    [SerializeField] [Range(0, 1)] float enemyExplosionVolume = 0.25f;
    [SerializeField] [Range(0, 1)] float miniBossExplosionVolume = 0.5f;
    [SerializeField] [Range(0, 1)] float enemyLaserVolume = 0.25f;
    [SerializeField] [Range(0, 1)] float laserImpactVolume = 0.1f;


    //NonSerializable
    EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        
        enemySpawner = FindObjectOfType<EnemySpawner>();
        healthbar.SetMaxHealth(enemyHealth);
        crystal = FindObjectOfType<Crystals>();
        StartCoroutine (EnemyFire());
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(enemyHealth);
        EnemyDeathCondition();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "PlayerLaser")
        {
            AudioSource.PlayClipAtPoint(enemyDeathSFX.GetLaserImpact(), Camera.main.transform.position, laserImpactVolume);
            PlayerLaser damageDealer = other.GetComponent<PlayerLaser>();
            ProcessHit(damageDealer);
            damageDealer.Hit();
            
            if(other.gameObject.name =="PlayerLaser5(Clone)")// this if is for sniperGun
            {
                Vector3 snipergunEffectLoc = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                GameObject sniperGunEffect = Instantiate(damageDealer.LaserHitEffect(), snipergunEffectLoc, Quaternion.identity);
                Destroy(sniperGunEffect, 1f);
            }
        }
        else if(other.gameObject.tag == "ThePlayer")
        {
            enemyHealthCopy = enemyHealth;
            PlayerStatus player = other.GetComponent<PlayerStatus>();
            enemyHealth -= player.GetPlayerHealth();
            player.DropPlayerHealth(enemyHealthCopy);

        }
        
        
    }

    public void ProcessHit(PlayerLaser damageDealer)
    {
        enemyHealth -= damageDealer.GetLaserDamage();
      
    }

    private void EnemyDeathCondition()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);

            //if the  vaule is bigger de 160 that means its a mini or big boss so will use another sound
            if (crystalValue < 180)
            {
               AudioSource.PlayClipAtPoint(enemyDeathSFX.GetEnemyExplosion(), Camera.main.transform.position, enemyExplosionVolume);
            }
            else
            {
                AudioSource.PlayClipAtPoint(enemyDeathSFX.GetMiniBossExplosion(), Camera.main.transform.position, miniBossExplosionVolume);
            }
           
            
            GameObject deathAnimation = Instantiate(enemyDeathAnimation, transform.position, Quaternion.identity);
            Destroy(deathAnimation, 3f);
            crystal.SetUpCrystals(crystalValue);
            EnemyDrop drop = GetComponent<EnemyDrop>();
            drop.Drop();

            enemySpawner.SetNumberOfDeadEnemies(1);
          

        }
    }

    IEnumerator EnemyFire()
    {
        
        

        
         while(fire == true)
         {
            Vector3 bulletLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            randomShot = Random.value;
            if (randomShot < shootingLaserChance)
            {
                GameObject enemyLaser = Instantiate(enemyBullet, bulletLocation, Quaternion.identity);
                AudioSource.PlayClipAtPoint(enemyDeathSFX.GetEnemyLaser(), Camera.main.transform.position, enemyLaserVolume);
                
                
                
            }
            yield return new WaitForSeconds(laserSpawnTime);

         }
    }



    public void DamageEnemy(float damageEnemy)
    {
        enemyHealth -= damageEnemy;
    }

    public float GetEnemyHealth()
    {
        return enemyHealth;
    }

   

    
   
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{


    [SerializeField] PlayerStats playerStats;
    [SerializeField] RestartWaveADS restartwave;
    UpgradePlayerGun upgradePlayerGun;
    float playerHealth;
    float addDamage = 0f;
    float healthCopy;
    HealthBar playerHealthBar;



    [Header("Player Particle Effects")]
    [SerializeField] GameObject playerDeathVFX;
    bool shieldOn = false;
    


    [Header("Player Sound Effects")]
    [SerializeField]SFX playerDeathSFX;
    [SerializeField][Range(0,1)] float playerExplosionVolume = 0.25f;
    [SerializeField][Range(0, 1)] float laserImpactVolume = 0.1f;
    [SerializeField] [Range(0, 1)] float shieldUpVolume = 0.4f;

    [Header("Camera Shake Effect")]
    [SerializeField] bool applyCameraShake = true;
    CameraShake cameraShake;

    

    //ForLosing WIndow
    GameObject buttonManager;
    ButtonsManager buttonM;
    GameObject canvas;

 
    //limits
    float maxPlayerHealth;

    private void Awake()
    {
        
        playerHealth = playerStats.GetPlayerHealth();
        addDamage = playerStats.GetBonusDamage();
        buttonManager = GameObject.FindGameObjectWithTag("ButtonManager");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        playerHealthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<HealthBar>();
    }
    // Start is called before the first frame update
    void Start()
    {
        upgradePlayerGun = GetComponent<UpgradePlayerGun>();    
        cameraShake = Camera.main.GetComponent<CameraShake>();
        buttonM = buttonManager.GetComponent<ButtonsManager>();
        healthCopy = playerHealth / 2f;
        playerHealthBar.SetMaxHealth(playerHealth);
        maxPlayerHealth = playerHealth;
        StartCoroutine(ShieldOn());
        
    }

    // Update is called once per frame
    void Update()
    {
        
        playerHealthBar.SetHealth(playerHealth);
        PlayerDeathCondition();
        LimitHealth();
        

    }


   public float GetPlayerStatsShield()
    {
        return playerStats.GetPlayerShield();
    }

    public void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake == true)
        {
            cameraShake.GetCameraShake();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyLaser")
        {
            AudioSource.PlayClipAtPoint(playerDeathSFX.GetLaserImpact(), Camera.main.transform.position, laserImpactVolume);
            EnemyLaser laser = collision.GetComponent<EnemyLaser>();
            PlayerGetHit(laser);

        }
        
    }

    private void PlayerGetHit(EnemyLaser laser)
    {
        
        laser.Hit();
        playerHealth -= laser.GetEnemyLaser();
        ShakeCamera();
        

    }

    private void PlayerDeath()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeathSFX.GetPlayerExplosion(), Camera.main.transform.position, playerExplosionVolume);
        GameObject explosion = Instantiate(playerDeathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);
        buttonM.SetPlayerDeath(true);
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        canvas.transform.GetChild(7).gameObject.SetActive(false);
        restartwave.SetUpPlayerGunLevel(upgradePlayerGun.GetUpgradeLevel());
        
        
    }

    private void PlayerDeathCondition()
    {
        if (playerHealth <= 0)
        {
           
            PlayerDeath();
           
        }
    }

    private void LimitHealth()
    {
        if(playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
    }


   IEnumerator ShieldOn()
    {
        while(true)
        {
            if(shieldOn == true)
            {
                
                GameObject shield = gameObject.transform.GetChild(1).gameObject;
                
                if (shield.activeSelf == true)
                {
                    
                    var playershield = shield.GetComponent<PlayerShield>();
                    playershield.SetShieldLife(playershield.GetRespawnShield());
                }
                else if (shield.activeSelf == false)
                {
                    shield.SetActive(true);
                }
                shieldOn = false;

            }
            yield return new WaitUntil(() => shieldOn == true);
        }
    }

  
   
    //SETS
    public void  DropPlayerHealth(float enemyHit)
    {
        playerHealth -= enemyHit;
    }

   

    public void HealPlayer()
    {
        
        playerHealth += healthCopy;
        
    }


    public void SetShield()
    {
        AudioSource.PlayClipAtPoint(playerDeathSFX.GetShieldDrop(), Camera.main.transform.position, shieldUpVolume);
        shieldOn = true;
    }


    //Gets
    public float GetPlayerHealth()
    {
        return playerHealth;
    }

    public float GetAddDamage()
    {
        return addDamage;
;   }



    

    

}

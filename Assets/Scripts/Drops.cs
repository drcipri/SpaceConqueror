using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] [Range(0, 1)] float dropVolume = 0.8f;
    [SerializeField] [Range(0, 1)] float forBadSounds = 1f;
    [SerializeField]float dropSpeed = -250f;
    
    [Header("Objects")]
    [SerializeField] GameObject straightGun;
    [SerializeField] GameObject shotGun;
    [SerializeField] GameObject grenadeGun;
    [SerializeField] GameObject tommyGun;
    [SerializeField] GameObject sniperGun;
    [SerializeField] GameObject zapGun;
    [SerializeField] GameObject beamLaser;
    [SerializeField] SFX dropSounds;
    
    [Header("Crystals")]
    [SerializeField]Crystals crystal;
    [SerializeField] GameObject extraCrystal;

    Rigidbody2D thisRigidbody;
    //for big bombs
    GameObject bigBombButton;
    
    



    private void OutOfBonds()
    {
        float yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        if (gameObject.transform.position.y < yMin)
        {
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        bigBombButton = GameObject.FindGameObjectWithTag("BigBombButton");
    }
    void Start()
    {
        DropItem();
    }

    private void Update()
    {
        OutOfBonds();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ThePlayer")
        {
            
            
            Player getPlayer = collision.GetComponent<Player>();
            PlayerStatus getPlayerStatus = collision.GetComponent<PlayerStatus>();
            UpgradePlayerGun getPlayerUpgrade = collision.GetComponent<UpgradePlayerGun>();
            if(gameObject.tag == "ShotGun")
            {
                
                ShotGunDrop(getPlayer);
                getPlayer.GunFire(true);
            }
            else if (gameObject.tag == "StraightGun")
            {
                
                StraightGunDrop(getPlayer);
                getPlayer.GunFire(true);
            }
            
            else if (gameObject.tag == "LifeDrop")
            {
                LifeDrop(getPlayerStatus);
            }
            else if (gameObject.tag == "Upgrade")
            {
                UpgradeDrop(getPlayerUpgrade);
            }
            else if (gameObject.tag == "GrenadeGun")
            {
                GrenadeGunDrop(getPlayer);
                getPlayer.GunFire(true);
            }
            else if (gameObject.tag == "ShieldDrop")
            {
                ShieldDrop(getPlayerStatus);
            }
            else if (gameObject.tag == "TommyGun")
            {
                TommyGunDrop(getPlayer);
                getPlayer.GunFire(true);
            }
            else if (gameObject.tag == "SniperGun")
            {
                SniperGunDrop(getPlayer);
                getPlayer.GunFire(true);
            }
            else if (gameObject.tag == "ZapGun")
            {
                ZapGunDrop(getPlayer);
                getPlayer.GunFire(true);
            }
            else if (gameObject.tag == "BeamLaser")
            {
                BeamLaserDrop(getPlayer);
                
            }else if(gameObject.tag == "BigBombRain")
            {
                BigBombRainDrop();
            }
            else if(gameObject.tag == "BigBombAtomic")
            {
                BigBombAtomic();
            }
            else if(gameObject.tag == "BigBombLaser")
            {
                BigBombLaser();
            }
            

            Destroy(gameObject);


        }
    }


    private void DropItem()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
        thisRigidbody.AddForce(transform.up * dropSpeed);
    }

    private void BeamLaserDrop(Player getPlayer)
    {
        getPlayer.SetUpPlayerGun(beamLaser);
        AudioSource.PlayClipAtPoint(dropSounds.GetBeamLaserDrop(), Camera.main.transform.position, dropVolume);
    }
    private void SniperGunDrop(Player getPlayer)
    {
        getPlayer.SetUpPlayerGun(sniperGun);
        AudioSource.PlayClipAtPoint(dropSounds.GetSniperGunDrop(), Camera.main.transform.position, forBadSounds);
    }

    private void ZapGunDrop(Player getPlayer)
    {
        getPlayer.SetUpPlayerGun(zapGun);
        AudioSource.PlayClipAtPoint(dropSounds.GetZapGunDrop(), Camera.main.transform.position, forBadSounds);
    }

    private void TommyGunDrop(Player getPlayer)
    {
        getPlayer.SetUpPlayerGun(tommyGun);
        AudioSource.PlayClipAtPoint(dropSounds.GetTommyGunDrop(), Camera.main.transform.position, forBadSounds);
    } 
   private void ShotGunDrop(Player getPlayer)
   {

        getPlayer.SetUpPlayerGun(shotGun);
        AudioSource.PlayClipAtPoint(dropSounds.GetShotGunDrop(), Camera.main.transform.position, dropVolume);
   }

    private void StraightGunDrop(Player getPlayer)
    {
        getPlayer.SetUpPlayerGun(straightGun);
        AudioSource.PlayClipAtPoint(dropSounds.GetStraightGunDrop(), Camera.main.transform.position, dropVolume);
    }

    private void GrenadeGunDrop(Player getPlayer)
    {
        getPlayer.SetUpPlayerGun(grenadeGun);
        AudioSource.PlayClipAtPoint(dropSounds.GetGrenadeGunDrop(), Camera.main.transform.position, dropVolume);
    }

    private void LifeDrop(PlayerStatus health)
    {
        health.HealPlayer();
        AudioSource.PlayClipAtPoint(dropSounds.GetLifeDrop(), Camera.main.transform.position, dropVolume);
    }


    private void UpgradeDrop(UpgradePlayerGun getUpgrade)
    {
        if (getUpgrade.GetUpgradeLevel() == 5)
        {
            crystal.SetUpCrystals(50);
            Instantiate(extraCrystal, gameObject.transform.position, Quaternion.identity);
        }
        getUpgrade.SetUpGunLevel(1);
        AudioSource.PlayClipAtPoint(dropSounds.GetUpgradeDrop(), Camera.main.transform.position, dropVolume);
       
    }

    private void ShieldDrop(PlayerStatus shield)
    {
        shield.SetShield();
    }

    private void BigBombRainDrop()
    {
        AudioSource.PlayClipAtPoint(dropSounds.GetBigBombDrop(), Camera.main.transform.position, forBadSounds);
        GameObject bombAtomic = bigBombButton.transform.GetChild(1).gameObject;
        GameObject bombLaser = bigBombButton.transform.GetChild(2).gameObject;
        GameObject bombRain = bigBombButton.transform.GetChild(0).gameObject;
        bombAtomic.SetActive(false);
        bombLaser.SetActive(false);
        bombRain.SetActive(true);

    }

    private void BigBombAtomic()
    {
        AudioSource.PlayClipAtPoint(dropSounds.GetBigBombDrop(), Camera.main.transform.position, forBadSounds);
        GameObject bombAtomic = bigBombButton.transform.GetChild(1).gameObject;
        GameObject bombLaser = bigBombButton.transform.GetChild(2).gameObject;
        GameObject bombRain = bigBombButton.transform.GetChild(0).gameObject;
        bombLaser.SetActive(false);
        bombRain.SetActive(false);
        bombAtomic.SetActive(true);
    }

    private void BigBombLaser()
    {
        AudioSource.PlayClipAtPoint(dropSounds.GetBigBombDrop(), Camera.main.transform.position, forBadSounds);
        GameObject bombAtomic = bigBombButton.transform.GetChild(1).gameObject;
        GameObject bombLaser = bigBombButton.transform.GetChild(2).gameObject;
        GameObject bombRain = bigBombButton.transform.GetChild(0).gameObject;
        bombRain.SetActive(false);
        bombAtomic.SetActive(false);
        bombLaser.SetActive(true);
    }



   

}

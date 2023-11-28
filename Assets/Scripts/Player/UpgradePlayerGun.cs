using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePlayerGun : MonoBehaviour
{
     [SerializeField]int upgradeGunLevel = 1;

    //SFX 
    [Header("Player Laser Sound")]
    [SerializeField] SFX playerLaserSFX;
    [SerializeField] [Range(0, 1)] float playerLaserVolume = 0.25f;
    [SerializeField] [Range(0, 1)] float tommyGunLaser = 0.25f;
    [SerializeField] [Range(0, 1)] float sniperGunVolume = 0.25f;

    Player player;
    PlayerStatus playerStatus;
    
    private void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        player = GetComponent<Player>();
        
    }

  


    private void FixedUpdate()
    {
        LimitGunLevel();
    }

    private void LimitGunLevel()
    {
        int maxGunlevel = 5;
        if(upgradeGunLevel > maxGunlevel)
        {
            upgradeGunLevel = maxGunlevel;
        }
    }


    public void SetUpGunLevel(int gunLevel)
    {
        this.upgradeGunLevel += gunLevel;
    }

    public int GetUpgradeLevel()
    {
        return upgradeGunLevel;
    }


    //for Respawning player
    public void SetUpgradeRespawnPlayer(int gunLevel)
    {
        this.upgradeGunLevel = gunLevel;
    }




    

    public void StraightGun()
    {
        AudioSource.PlayClipAtPoint(playerLaserSFX.GetPlayerLaser(0), Camera.main.transform.position,
            playerLaserVolume);
        if(upgradeGunLevel == 1)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x - 0.25f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x + 0.25f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(180f, playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(180f,playerStatus);
        }
        else if(upgradeGunLevel == 2)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y + 0.5f,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity); 
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.5f , transform.position.y, 
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.identity);
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);

        }
        else if(upgradeGunLevel == 3)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y + 1f,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.identity);
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.identity);
            Vector3 bulletPosition4 = new Vector3(transform.position.x - 1f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet4 = Instantiate(player.GetLaser(), bulletPosition4, Quaternion.identity);
            Vector3 bulletPosition5 = new Vector3(transform.position.x + 1f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet5 = Instantiate(player.GetLaser(), bulletPosition5, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(260f, playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(260f, playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(260f, playerStatus);
            bullet4.GetComponent<PlayerLaser>().SetLaserDamage(260f, playerStatus);
            bullet5.GetComponent<PlayerLaser>().SetLaserDamage(260f, playerStatus);

        }

        else if(upgradeGunLevel == 4)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y + 1f,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.identity);
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.identity);
            Vector3 bulletPosition4 = new Vector3(transform.position.x - 1f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet4 = Instantiate(player.GetLaser(), bulletPosition4, Quaternion.identity);
            Vector3 bulletPosition5 = new Vector3(transform.position.x + 1f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet5 = Instantiate(player.GetLaser(), bulletPosition5, Quaternion.identity);
            Vector3 bulletPosition6 = new Vector3(transform.position.x - 1f, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet6 = Instantiate(player.GetLaser(), bulletPosition6, Quaternion.Euler(0,0,4));
            Vector3 bulletPosition7 = new Vector3(transform.position.x + 1f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet7 = Instantiate(player.GetLaser(), bulletPosition7, Quaternion.Euler(0,0,-4));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(260f,playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(260f,playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(260f,playerStatus);
            bullet4.GetComponent<PlayerLaser>().SetLaserDamage(260f,playerStatus);
            bullet5.GetComponent<PlayerLaser>().SetLaserDamage(260f,playerStatus);
            bullet6.GetComponent<PlayerLaser>().SetLaserDamage(260f,playerStatus);
            bullet7.GetComponent<PlayerLaser>().SetLaserDamage(260f,playerStatus);
           

        }

        else if(upgradeGunLevel == 5)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y + 1f,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.identity);
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.identity);
            Vector3 bulletPosition4 = new Vector3(transform.position.x - 1f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet4 = Instantiate(player.GetLaser(), bulletPosition4, Quaternion.identity);
            Vector3 bulletPosition5 = new Vector3(transform.position.x + 1f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet5 = Instantiate(player.GetLaser(), bulletPosition5, Quaternion.identity);
            Vector3 bulletPosition6 = new Vector3(transform.position.x - 1f, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet6 = Instantiate(player.GetLaser(), bulletPosition6, Quaternion.Euler(0, 0, 4));
            Vector3 bulletPosition7 = new Vector3(transform.position.x + 1f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet7 = Instantiate(player.GetLaser(), bulletPosition7, Quaternion.Euler(0, 0, -4));
            Vector3 bulletPosition8 = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f,
                transform.position.z + 1f);
            GameObject bullet8 = Instantiate(player.GetLaser(), bulletPosition8, Quaternion.Euler(0,0,4));
            Vector3 bulletPosition9 = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f,
                transform.position.z + 1f);
            GameObject bullet9 = Instantiate(player.GetLaser(), bulletPosition9, Quaternion.Euler(0,0,-4));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet4.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet5.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet6.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet7.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet8.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet9.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            

        }
    }

    public void ShotGun()
    {
        AudioSource.PlayClipAtPoint(playerLaserSFX.GetPlayerLaser(1), Camera.main.transform.position,
            playerLaserVolume);
        
        if (upgradeGunLevel == 1)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.Euler(0,0,5f));
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.Euler(0,0,-5f));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(140f, playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(140f, playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(140f, playerStatus);
        }

        else if(upgradeGunLevel == 2)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.2f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.Euler(0, 0, 4f));
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.2f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.Euler(0, 0, -4f));
            Vector3 bulletPosition4 = new Vector3(transform.position.x - 0.4f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet4 = Instantiate(player.GetLaser(), bulletPosition4, Quaternion.Euler(0, 0, 8f));
            Vector3 bulletPosition5 = new Vector3(transform.position.x + 0.4f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet5 = Instantiate(player.GetLaser(), bulletPosition5, Quaternion.Euler(0,0,-8f));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(200f, playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(200f, playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(200f, playerStatus);
            bullet4.GetComponent<PlayerLaser>().SetLaserDamage(200f, playerStatus);
            bullet5.GetComponent<PlayerLaser>().SetLaserDamage(200f, playerStatus);
        }
        else if(upgradeGunLevel == 3)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.2f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.Euler(0, 0, 4f));
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.2f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.Euler(0, 0, -4f));
            Vector3 bulletPosition4 = new Vector3(transform.position.x - 0.4f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet4 = Instantiate(player.GetLaser(), bulletPosition4, Quaternion.Euler(0, 0, 8f));
            Vector3 bulletPosition5 = new Vector3(transform.position.x + 0.4f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet5 = Instantiate(player.GetLaser(), bulletPosition5, Quaternion.Euler(0, 0, -8f));
            Vector3 bulletPosition6 = new Vector3(transform.position.x - 0.6f, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet6 = Instantiate(player.GetLaser(), bulletPosition6, Quaternion.Euler(0, 0, 12f));
            Vector3 bulletPosition7 = new Vector3(transform.position.x + 0.6f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet7 = Instantiate(player.GetLaser(), bulletPosition7, Quaternion.Euler(0, 0, -12f));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(260f, playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(260f, playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(260f, playerStatus);
            bullet4.GetComponent<PlayerLaser>().SetLaserDamage(260f, playerStatus);
            bullet5.GetComponent<PlayerLaser>().SetLaserDamage(260f, playerStatus);
            bullet6.GetComponent<PlayerLaser>().SetLaserDamage(260f, playerStatus);
            bullet7.GetComponent<PlayerLaser>().SetLaserDamage(260f, playerStatus);
        }

        else if(upgradeGunLevel == 4)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.2f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.Euler(0, 0, 4f));
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.2f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.Euler(0, 0, -4f));
            Vector3 bulletPosition4 = new Vector3(transform.position.x - 0.4f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet4 = Instantiate(player.GetLaser(), bulletPosition4, Quaternion.Euler(0, 0, 8f));
            Vector3 bulletPosition5 = new Vector3(transform.position.x + 0.4f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet5 = Instantiate(player.GetLaser(), bulletPosition5, Quaternion.Euler(0, 0, -8f));
            Vector3 bulletPosition6 = new Vector3(transform.position.x - 0.6f, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet6 = Instantiate(player.GetLaser(), bulletPosition6, Quaternion.Euler(0, 0, 12f));
            Vector3 bulletPosition7 = new Vector3(transform.position.x + 0.6f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet7 = Instantiate(player.GetLaser(), bulletPosition7, Quaternion.Euler(0, 0, -12f));
            Vector3 bulletPosition8 = new Vector3(transform.position.x, transform.position.y + 1f,
              transform.position.z + 1f);
            GameObject bullet8 = Instantiate(player.GetLaser(), bulletPosition8, Quaternion.identity);
            Vector3 bulletPosition9 = new Vector3(transform.position.x - 0.2f, transform.position.y + 1,
                transform.position.z + 1f);
            GameObject bullet9 = Instantiate(player.GetLaser(), bulletPosition9, Quaternion.Euler(0, 0, 4f));
            Vector3 bulletPosition10 = new Vector3(transform.position.x + 0.2f, transform.position.y + 1f,
                transform.position.z + 1f);
            GameObject bullet10 = Instantiate(player.GetLaser(), bulletPosition10, Quaternion.Euler(0, 0, -4f));

            bullet.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet4.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet5.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet6.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet7.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet8.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet9.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);
            bullet10.GetComponent<PlayerLaser>().SetLaserDamage(240f, playerStatus);


        }

        else if(upgradeGunLevel == 5)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
              transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.2f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.Euler(0, 0, 4f));
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.2f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.Euler(0, 0, -4f));
            Vector3 bulletPosition4 = new Vector3(transform.position.x - 0.4f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet4 = Instantiate(player.GetLaser(), bulletPosition4, Quaternion.Euler(0, 0, 8f));
            Vector3 bulletPosition5 = new Vector3(transform.position.x + 0.4f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet5 = Instantiate(player.GetLaser(), bulletPosition5, Quaternion.Euler(0, 0, -8f));
            Vector3 bulletPosition6 = new Vector3(transform.position.x - 0.6f, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet6 = Instantiate(player.GetLaser(), bulletPosition6, Quaternion.Euler(0, 0, 12f));
            Vector3 bulletPosition7 = new Vector3(transform.position.x + 0.6f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet7 = Instantiate(player.GetLaser(), bulletPosition7, Quaternion.Euler(0, 0, -12f));
            Vector3 bulletPosition8 = new Vector3(transform.position.x, transform.position.y + 1,
              transform.position.z + 1f);
            GameObject bullet8 = Instantiate(player.GetLaser(), bulletPosition8, Quaternion.identity);
            Vector3 bulletPosition9 = new Vector3(transform.position.x - 0.2f, transform.position.y + 1f,
                transform.position.z + 1f);
            GameObject bullet9 = Instantiate(player.GetLaser(), bulletPosition9, Quaternion.Euler(0, 0, 4f));
            Vector3 bulletPosition10 = new Vector3(transform.position.x + 0.2f, transform.position.y + 1f,
                transform.position.z + 1f);
            GameObject bullet10 = Instantiate(player.GetLaser(), bulletPosition10, Quaternion.Euler(0, 0, -4f));
            Vector3 bulletPosition11 = new Vector3(transform.position.x - 0.4f, transform.position.y + 1f,
                transform.position.z + 1f);
            GameObject bullet11 = Instantiate(player.GetLaser(), bulletPosition11, Quaternion.Euler(0, 0, 8f));
            Vector3 bulletPosition12 = new Vector3(transform.position.x + 0.4f, transform.position.y + 1f,
                transform.position.z + 1f);
            GameObject bullet12 = Instantiate(player.GetLaser(), bulletPosition12, Quaternion.Euler(0, 0, -8f));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet4.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet5.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet6.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet7.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet8.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet9.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet10.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet11.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);
            bullet12.GetComponent<PlayerLaser>().SetLaserDamage(230f, playerStatus);

        }
    }

    public void GrenadeGun()
    {
        
        AudioSource.PlayClipAtPoint(playerLaserSFX.GetPlayerLaser(2), Camera.main.transform.position, playerLaserVolume);
        if (upgradeGunLevel == 1)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + 1);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(500f, playerStatus);
        }

        else if(upgradeGunLevel == 2)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x - 0.5f, transform.position.y,
                transform.position.z + 1);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(600f, playerStatus);
            
            Vector3 bulletPosition1 = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1);
            GameObject bullet1 = Instantiate(player.GetLaser(), bulletPosition1, Quaternion.identity);
            bullet1.GetComponent<PlayerLaser>().SetLaserDamage(600f, playerStatus);

        }
        else if(upgradeGunLevel == 3)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x - 0.5f, transform.position.y,
               transform.position.z + 1);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(800f, playerStatus);
            
            Vector3 bulletPosition1 = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1);
            GameObject bullet1 = Instantiate(player.GetLaser(), bulletPosition1, Quaternion.identity);
            bullet1.GetComponent<PlayerLaser>().SetLaserDamage(800f, playerStatus);

        }
        else if(upgradeGunLevel == 4)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
              transform.position.z + 1);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);          
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.Euler(0, 0, 5f));
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.Euler(0, 0, -5f));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);
            
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);
            
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);
            

        }
        else if(upgradeGunLevel == 5)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x + 0.5f, transform.position.y,
            transform.position.z + 1);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition1 = new Vector3(transform.position.x - 0.5f, transform.position.y,
           transform.position.z + 1);
            GameObject bullet1 = Instantiate(player.GetLaser(), bulletPosition1, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 1f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.Euler(0, 0, 5f));
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 1f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.Euler(0, 0, -5f));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);
            
            bullet1.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);

            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);
            
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);
            
        }
    }

    public void TommyGun()
    {
        Player player = GetComponent<Player>();
        AudioSource.PlayClipAtPoint(playerLaserSFX.GetPlayerLaser(3), Camera.main.transform.position, tommyGunLaser);
        
        
       
        if (upgradeGunLevel == 1)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(100f, playerStatus);
        }
        else if (upgradeGunLevel == 2)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(200f, playerStatus);
        }
        else if (upgradeGunLevel == 3)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x + -0.5f, transform.position.y,
                         transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.identity);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(200f, playerStatus);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(200f, playerStatus);
        }
        else if (upgradeGunLevel == 4)
        {
            
            Vector3 bulletPosition = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x + -0.5f, transform.position.y,
                         transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.identity);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(250f, playerStatus);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(250f, playerStatus);
            if( player.name == "Player9(Clone)" || player.name == "Player12(Clone)" || player.name == "Player15(Clone)")
            {
                Vector3 bulletPosition3 = new Vector3(transform.position.x, transform.position.y + 0.5f,
                  transform.position.z + 1f);
                GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.identity);
                bullet3.GetComponent<PlayerLaser>().SetLaserDamage(100f, playerStatus);
            }
                
           
        }
        else if (upgradeGunLevel == 5)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x + -0.5f, transform.position.y,
                  transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.identity);
            Vector3 bulletPosition3 = new Vector3(transform.position.x, transform.position.y + 0.5f,
                  transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.identity);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(220f, playerStatus);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(220f, playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(220f, playerStatus);
            if (player.name == "Player9(Clone)" || player.name == "Player12(Clone)" || player.name == "Player15(Clone)")
            {
                Vector3 bulletPosition4 = new Vector3(transform.position.x + 1f , transform.position.y - 0.3f,
                  transform.position.z + 1f);
                GameObject bullet4 = Instantiate(player.GetLaser(), bulletPosition4, Quaternion.identity);
                bullet4.GetComponent<PlayerLaser>().SetLaserDamage(-600f, playerStatus);
                Vector3 bulletPosition5 = new Vector3(transform.position.x - 1f, transform.position.y - 0.3f,
                  transform.position.z + 1f);
                GameObject bullet5 = Instantiate(player.GetLaser(), bulletPosition5, Quaternion.identity);
                bullet5.GetComponent<PlayerLaser>().SetLaserDamage(-600f, playerStatus);
            }

        }
    }

    public void SniperGun()
    {
        
        AudioSource.PlayClipAtPoint(playerLaserSFX.GetPlayerLaser(4), Camera.main.transform.position, sniperGunVolume);
        if (upgradeGunLevel == 1)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(400f, playerStatus);
        }
        else if (upgradeGunLevel == 2)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(600f, playerStatus);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.5f, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.identity);
        }

        else if (upgradeGunLevel == 3)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.5f, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.Euler(0, 0, 5f));
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.Euler(0, 0, -5f));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(500f, playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(500f, playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(500f, playerStatus);

        }
        else if (upgradeGunLevel == 4)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.5f, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.Euler(0, 0, 5f));
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.Euler(0, 0, -5f));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(600f, playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(600f, playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(600f, playerStatus);
        }
        else if (upgradeGunLevel == 5)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.5f, transform.position.y,
               transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.Euler(0, 0, 5f));
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.Euler(0, 0, -5f));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(750f, playerStatus);
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(750f, playerStatus);
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(750f, playerStatus);
            
        }



    }

    public void ZapGun()
    {
        
        AudioSource.PlayClipAtPoint(playerLaserSFX.GetPlayerLaser(5), Camera.main.transform.position, sniperGunVolume);

        if (upgradeGunLevel == 1)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + 1);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(400f, playerStatus);
        }

        else if (upgradeGunLevel == 2)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x - 0.5f, transform.position.y,
               transform.position.z + 1);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(600f, playerStatus);

            Vector3 bulletPosition1 = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1);
            GameObject bullet1 = Instantiate(player.GetLaser(), bulletPosition1, Quaternion.identity);
            bullet1.GetComponent<PlayerLaser>().SetLaserDamage(600f, playerStatus);

        }
        else if (upgradeGunLevel == 3)
        {

            Vector3 bulletPosition = new Vector3(transform.position.x - 0.5f, transform.position.y,
               transform.position.z + 1);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(800f, playerStatus);

            Vector3 bulletPosition1 = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1);
            GameObject bullet1 = Instantiate(player.GetLaser(), bulletPosition1, Quaternion.identity);
            bullet1.GetComponent<PlayerLaser>().SetLaserDamage(800f, playerStatus);
        }
        else if (upgradeGunLevel == 4)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
              transform.position.z + 1);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.Euler(0, 0, 5f));
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 0.5f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.Euler(0, 0, -5f));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);
           
            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);
            
            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);
            

        }
        else if (upgradeGunLevel == 5)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x + 0.5f, transform.position.y,
           transform.position.z + 1);
            GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            Vector3 bulletPosition1 = new Vector3(transform.position.x - 0.5f, transform.position.y,
           transform.position.z + 1);
            GameObject bullet1 = Instantiate(player.GetLaser(), bulletPosition1, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 1f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet2 = Instantiate(player.GetLaser(), bulletPosition2, Quaternion.Euler(0, 0, 5f));
            Vector3 bulletPosition3 = new Vector3(transform.position.x + 1f, transform.position.y,
                transform.position.z + 1f);
            GameObject bullet3 = Instantiate(player.GetLaser(), bulletPosition3, Quaternion.Euler(0, 0, -5f));
            bullet.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);

            bullet1.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);

            bullet2.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);

            bullet3.GetComponent<PlayerLaser>().SetLaserDamage(700f, playerStatus);

        }
    }

    public void LaserBeamGun()
    {
        
        
        Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + 1f);
        GameObject bullet = Instantiate(player.GetLaser(), bulletPosition, Quaternion.identity);
            
        
        
    }


    
   


}

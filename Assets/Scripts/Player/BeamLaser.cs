using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamLaser : MonoBehaviour
{
    
    GameObject getPlayer;
    Transform firePoint1;
    Transform firePoint2;
   
    Player player;
    PlayerStatus playerStatus;
    UpgradePlayerGun upgradeLevel;
 
    LineRenderer lineRenderer;
    PlayerLaser damage;
    BeamLaser beamLaser;

    GameObject startParticles;
    GameObject endParticles;
    

    AudioSource playSound;
    AudioClip beamSound;
    [SerializeField] SFX laserSound;


    int check = 0;

    private void Awake()
    {

        getPlayer = GameObject.FindGameObjectWithTag("ThePlayer");
        firePoint1 = getPlayer.transform.GetChild(3).transform;
        firePoint2 = getPlayer.transform.GetChild(4).transform;
        endParticles = transform.GetChild(2).gameObject;
        startParticles = transform.GetChild(1).gameObject;
        

    }

    private void Start()
    {
        
        PlaySound();
        playerStatus = getPlayer.GetComponent<PlayerStatus>();
        player = getPlayer.GetComponent<Player>();
        lineRenderer = gameObject.transform.GetChild(0).GetComponent<LineRenderer>();
        damage = gameObject.GetComponentInParent(typeof(PlayerLaser)) as PlayerLaser;
        LaserPosition(firePoint1.transform.position, firePoint2.transform.position);


    }

    private void PlaySound()
    {
        playSound = GetComponent<AudioSource>();
        beamSound = laserSound.GetPlayerLaser(6);
        playSound.clip = beamSound;
        playSound.Play();
    }

    private void Update()
    {
        startParticles.transform.position = firePoint1.transform.position;
        RayCastandBeamLaserPos();
        if (player.GetLaser().name != "PlayerLaser7")
        {
            Destroy(gameObject);
        }
        if(playerStatus.GetPlayerHealth() <= 0f)
        {
            Destroy(gameObject);
        }
        LaserDamage();
        
        
       
    }
    



    private void RayCastandBeamLaserPos()
    {

        RaycastHit2D hit = Physics2D.Raycast(firePoint1.transform.position, transform.up);
        
        if (hit.collider != null)
        {



           if (hit.collider.TryGetComponent<EnemyStatus>(out EnemyStatus enemy))
           {
                    LaserPosition(firePoint1.transform.position, hit.point);
                    enemy.ProcessHit(damage);
                    endParticles.transform.position = hit.point;
                    
           }

           else if (hit.collider.TryGetComponent<EnemyBossshield>(out EnemyBossshield enemyShield))
           {
                    LaserPosition(firePoint1.transform.position, hit.point);
                    enemyShield.EnemyShieldHit(damage);
                    endParticles.transform.position = hit.point;
                    
           }

        }

        else
        {
            LaserPosition(firePoint1.transform.position, firePoint2.transform.position);
            endParticles.transform.position = firePoint2.transform.position;
            

        }

    }


    private void LaserPosition(Vector2 firePoint,Vector2 endPoint)
    {
        lineRenderer.SetPosition(0, firePoint);
        lineRenderer.SetPosition(1, endPoint);
    }


    private void LaserDamage()
    {
        beamLaser = GetComponent<BeamLaser>();
        upgradeLevel = getPlayer.GetComponent<UpgradePlayerGun>();
        
        if (check < upgradeLevel.GetUpgradeLevel())
        {
            if (upgradeLevel.GetUpgradeLevel() == 1)
            {
                damage.SetLaserDamage(40f,playerStatus, beamLaser);
                check++;
            }
            else if (upgradeLevel.GetUpgradeLevel() == 2)
            {
                damage.SetLaserDamage(80f,playerStatus, beamLaser);
                check++;
            }
            else if (upgradeLevel.GetUpgradeLevel() == 3)
            {
                damage.SetLaserDamage(100f, playerStatus, beamLaser);
                check++;
            }
            else if (upgradeLevel.GetUpgradeLevel() == 4)
            {
                damage.SetLaserDamage(150f, playerStatus, beamLaser);
                check++;
            }
            else if (upgradeLevel.GetUpgradeLevel() == 5)
            {
                damage.SetLaserDamage(190f,playerStatus, beamLaser);
                check++;
            }
        }
    }





}
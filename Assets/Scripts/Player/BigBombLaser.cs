using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBombLaser : MonoBehaviour
{
    [SerializeField] float laserDamage = 100f;
    [SerializeField] float fireLaserCountDown = 3f;
    [SerializeField] float laserDuration = 6f;
    

    GameObject getPlayer;
    Transform firePoint1;
    Transform firePoint2;

    
    PlayerStatus playerStatus;
    Player player;
    BigBombs bigBombs;

    LineRenderer lineRenderer;

    GameObject startParticles;
    GameObject endParticles;

    [SerializeField] SFX laserSound;
    [SerializeField] [Range(0, 1)] float volume = 0.8f;
    AudioSource playSound;
    AudioClip beamSound;
    bool play = true;



    private void Awake()
    {
        getPlayer = GameObject.FindGameObjectWithTag("ThePlayer");
        firePoint1 = getPlayer.transform.GetChild(3).transform;
        firePoint2 = getPlayer.transform.GetChild(4).transform;
        endParticles = transform.GetChild(2).gameObject;
        startParticles = transform.GetChild(1).gameObject;
    }


    // Start is called before the first frame update
    void Start()
    {
        playerStatus = getPlayer.GetComponent<PlayerStatus>();
        player = getPlayer.GetComponent<Player>();
        bigBombs = getPlayer.GetComponent<BigBombs>();
        lineRenderer = gameObject.transform.GetChild(0).GetComponent<LineRenderer>();
        AudioSource.PlayClipAtPoint(laserSound.GetLasercharge(), Camera.main.transform.position, volume);


    }

    // Update is called once per frame
    void Update()
    {
        
        FireLaser();
        if (playerStatus.GetPlayerHealth() <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void PlaySound()
    {
        if (play == true)
        {
            AudioSource.PlayClipAtPoint(laserSound.GetLaserShot(), Camera.main.transform.position, volume);
            playSound = GetComponent<AudioSource>();
            beamSound = laserSound.GetPlayerLaser(6);
            playSound.clip = beamSound;
            playSound.Play();
            play = false;
        }
    }
    private void LaserPosition(Vector2 firePoint, Vector2 endPoint)
    {
        lineRenderer.SetPosition(0, firePoint);
        lineRenderer.SetPosition(1, endPoint);
    }

    private void RayCastandBeamLaserPos()
    {

        PlaySound();
        lineRenderer.enabled = true;
        RaycastHit2D hit = Physics2D.Raycast(firePoint1.transform.position, transform.up);
        
        if (hit.collider != null)
        {



            if (hit.collider.TryGetComponent<EnemyStatus>(out EnemyStatus enemy))
            {
                LaserPosition(firePoint1.transform.position, hit.point);
                enemy.DamageEnemy(laserDamage);
                endParticles.transform.position = hit.point;
                endParticles.SetActive(true);

            }

            else if (hit.collider.TryGetComponent<EnemyBossshield>(out EnemyBossshield enemyShield))
            {
                LaserPosition(firePoint1.transform.position, hit.point);
                enemyShield.DamageShield(laserDamage);
                endParticles.transform.position = hit.point;
                endParticles.SetActive(true);

            }

        }

        else
        {
            LaserPosition(firePoint1.transform.position, firePoint2.transform.position);
            endParticles.transform.position = firePoint2.transform.position;

        }

        laserDuration -= Time.deltaTime;
        if(laserDuration < 0.6f)
        {
            lineRenderer.widthMultiplier -= Time.deltaTime;
        }
        if(laserDuration <= 0f)
        {
            player.SetBeamLaserOnOff(true);
            player.SetStopFireForBigBombs(false);
            Destroy(gameObject);
            bigBombs.SetFinishedLaunching(true);

        }

    }

    private void FireLaser()
    {
        startParticles.transform.position = firePoint1.transform.position;
        fireLaserCountDown -= Time.deltaTime;
        if(fireLaserCountDown <= 0)
        {
            RayCastandBeamLaserPos();
        }

    }
}

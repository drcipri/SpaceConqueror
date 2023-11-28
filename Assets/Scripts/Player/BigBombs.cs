using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBombs : MonoBehaviour
{
    [SerializeField] GameObject bigBombRain;
    [SerializeField] GameObject bigBombAtomic;
    [SerializeField] GameObject bigBombLaser;
    [SerializeField] SFX sfx;
    [SerializeField] float volume = 5f;
    [Header("RainBomb")]
    [SerializeField]float fireTime = 0.3f;
    [SerializeField]int numberOfRainRockets = 20;
    bool finisedLaunching = true;
    
   
    bool fireBigBomb = false;
    bool bigBombRainFire = false;
    bool bigBombAtomicFire = false;
    bool bigBombLaserFire = false;

    Player player;

    
    private void Start()
    {
        
        player = GetComponent<Player>();
        StartCoroutine(ShootingBigBombs());
    }
    IEnumerator BigBombRain()
    {
        
        for (int fireRockets = 0; fireRockets <= numberOfRainRockets;  )
        {
            AudioSource.PlayClipAtPoint(sfx.GetRocketLaunch(), Camera.main.transform.position, volume);
            Vector3 bulletPosition = new Vector3(transform.position.x + 0.5f , transform.position.y,
                       transform.position.z + 1f);
            GameObject bullet = Instantiate(bigBombRain, bulletPosition, Quaternion.identity);
            Vector3 bulletPosition2 = new Vector3(transform.position.x - 0.5f, transform.position.y,
                       transform.position.z + 1f);
            GameObject bullet2 = Instantiate(bigBombRain, bulletPosition2, Quaternion.identity);

            fireRockets++;
            if (fireRockets > numberOfRainRockets)
            {
                player.SetBeamLaserOnOff(true);
                player.SetStopFireForBigBombs(false);
                finisedLaunching = true;

            }
            
            yield return new WaitForSeconds(fireTime);

        }
    }

    private void BigBombAtomic()
    {
        Vector3 rocketPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
        GameObject rocket = Instantiate(bigBombAtomic, rocketPosition, Quaternion.identity);
    }

    private void BigBombLaser()
    {
        Vector3 rocketPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
        GameObject laser = Instantiate(bigBombLaser, rocketPosition, Quaternion.identity);
    }

    IEnumerator ShootingBigBombs()
    {
        while(true)
        {
            
            if(bigBombRainFire == true)
            {
                StartCoroutine(BigBombRain());
                fireBigBomb = false;
                bigBombRainFire = false;
                finisedLaunching = false;
            }
            else if(bigBombAtomicFire == true)
            {
                BigBombAtomic();
                fireBigBomb = false;
                bigBombAtomicFire = false;
                finisedLaunching = false;
            }
            else if(bigBombLaserFire == true)
            {
                BigBombLaser();
                fireBigBomb = false;
                bigBombLaserFire = false;
                finisedLaunching = false;
            }
            yield return new WaitUntil(() => fireBigBomb == true);
        }
    }

    public bool GetFinishedLaunching()
    {
        return finisedLaunching;
    }
    public void SetFinishedLaunching(bool finishedLaunching)
    {
        this.finisedLaunching=finishedLaunching;
    }
    public void SetFireBigBomb(bool fireBigBomb)
    {
        this.fireBigBomb = fireBigBomb;
    }
    //rain
    public void SetFireBigBombRain(bool rain)
    {
        this.bigBombRainFire = rain;
    }

    //atomic
    public void SetFireBigBombAtomic(bool atomic)
    {
        this.bigBombAtomicFire = atomic;
    }
    //laser
    public void SetFireBigBombLaser(bool laser)
    {
        this.bigBombLaserFire = laser;
    }
    
    
    
    
    
}

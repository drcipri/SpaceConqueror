using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField] AudioClip enemyExplosion;
    [SerializeField] AudioClip playerExplosion;
    [SerializeField] AudioClip grenadeGunExplosion;
    [SerializeField] AudioClip zapGunExplosion;
    [SerializeField] AudioClip laserImpact;
    [SerializeField] List<AudioClip> playerLaser;
    [SerializeField] AudioClip enemyLaser;
    [SerializeField] List<AudioClip> backgroundMusic;
    [SerializeField] AudioClip shotGunDrop;
    [SerializeField] AudioClip straightGunDrop;
    [SerializeField] AudioClip lifeDrop;
    [SerializeField] AudioClip upgradeDrop;
    [SerializeField] AudioClip grenadeGunDrop;
    [SerializeField] AudioClip shieldDrop;
    [SerializeField] AudioClip shieldDown;
    [SerializeField] AudioClip tommyGunDrop;
    [SerializeField] AudioClip sniperGunDrop;
    [SerializeField] AudioClip zapGunDrop;
    [SerializeField] AudioClip beamLaserDrop;
    [SerializeField] AudioClip engagingEnemy;
    [SerializeField] AudioClip miniBossExplosion;
    [SerializeField] AudioClip bossMissileSound;
    [SerializeField] AudioClip rocketLaunch;
    [SerializeField] AudioClip rocketExplosion;
    [SerializeField] AudioClip bigBombDrop;
    [SerializeField] AudioClip atomicExplosion;
    [SerializeField] AudioClip laserCharge;
    [SerializeField] AudioClip laserShot;
    [SerializeField] AudioClip rainBombExplosion;
    [SerializeField] AudioClip generalButton;
    [SerializeField] AudioClip lifeUpgrade;
    [SerializeField] AudioClip attackUpgrade;
    [SerializeField] AudioClip shieldUpgrade;
    [SerializeField] AudioClip targetAquired;

    public AudioClip GetTargetAquired()
    {
        return targetAquired;
    }
    public  AudioClip GetLifeUpgrade()
    {
        return lifeUpgrade;
    }
    public AudioClip GetAttackUpgrade()
    {
        return attackUpgrade;
    }
    public AudioClip GetShieldUpgrade()
    {
        return shieldUpgrade;
    }
    public AudioClip GeneralButton()
    {
        return generalButton;
    }
    public AudioClip GetRainBombExplosion()
    {
        return rainBombExplosion;
    }
    public AudioClip GetLaserShot()
    {
        return laserShot;
    }
    public AudioClip GetLasercharge()
    {
        return laserCharge;
    }
    public AudioClip GetAtomicExplosion()
    {
        return atomicExplosion;
    }
    public AudioClip GetBigBombDrop()
    {
        return bigBombDrop;
    }
    public AudioClip GetEnemyExplosion()
    {
        return enemyExplosion;
    }
    public AudioClip GetPlayerExplosion()
    {
        return playerExplosion;
    }
    
    public AudioClip GetLaserImpact()
    {
        return laserImpact;
    }
    
    public AudioClip GetPlayerLaser(int playerLaserIndex)
    {
        return playerLaser[playerLaserIndex];
    }
    public AudioClip GetEnemyLaser()
    {
        return enemyLaser;
    }

    public AudioClip GetBackgroundMusic(int backgroundMusicIndex)
    {
        return backgroundMusic[backgroundMusicIndex];
    }

    public AudioClip GetShotGunDrop()
    {
        return shotGunDrop;
    }

    public AudioClip GetStraightGunDrop()
    {
        return straightGunDrop;
    }

    public AudioClip GetLifeDrop()
    {
        return lifeDrop;
    }
    public AudioClip GetUpgradeDrop()
    {
        return upgradeDrop;
    }
    
    public AudioClip GetGrenadeGunExplosion()
    {
        return grenadeGunExplosion;
    }

    public AudioClip GetGrenadeGunDrop()
    {
        return grenadeGunDrop;
    }

    public AudioClip GetShieldDrop()
    {
        return shieldDrop;
    }
    public AudioClip GetShieldDown()
    {
        return shieldDown;
    }
    public AudioClip GetTommyGunDrop()
    {
        return tommyGunDrop;
    }

    public AudioClip GetSniperGunDrop()
    {
        return sniperGunDrop;
    }
    
    public AudioClip GetZapGunDrop()
    {
        return zapGunDrop;
    }
    public AudioClip GetBeamLaserDrop()
    {
        return beamLaserDrop;
    }

    public AudioClip GetZapGunExplosion()
    {
        return zapGunExplosion;
    }

    public AudioClip GetEngagingEnemy()
    {
        return engagingEnemy;
    }

    public AudioClip GetMiniBossExplosion()
    {
        return miniBossExplosion;
    }
    public AudioClip GetBossMissileSound()
    {
        return bossMissileSound;
    }

    public AudioClip GetRocketLaunch()
    {
        return rocketLaunch;
    }
    public AudioClip GetRocketExplosion()
    {
        return rocketExplosion;
    }
    
 }

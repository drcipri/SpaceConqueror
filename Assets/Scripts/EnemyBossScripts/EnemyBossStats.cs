using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BossStats")]
public class EnemyBossStats : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float bossSpeed;
    [SerializeField] int minRandomNumber;
    [SerializeField] int maxRandomNumber;

    [Header("Drops")]
    [SerializeField] List<GameObject> drops;
    [SerializeField] float dropRate;
    [SerializeField] float dropCountDown;

    [Header("Shield")]
    [SerializeField] float shieldLife;
    [SerializeField] bool shieldActive;

    [Header("Guns")]
    [SerializeField] List<GameObject> additionalGuns;
    [Header("GunOne Instatiate 1 Time")]
    [SerializeField] float missileCountDownOne;
    [SerializeField] bool bombOne;
    [Header("GunTwo Instatiate 3 Times")]
    [SerializeField] float missileCountDownTwo;
    [SerializeField] bool bombTwo;
    [Header("GunThree Instatiate 5 Times(Mines)")]
    [SerializeField] float missileCountDownThree;
    [SerializeField] bool bombThree;

    
    



    //GETS
    public List<Transform> GetBossBattleMovementPoints()
    {
        var bossBattleMovementPoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            bossBattleMovementPoints.Add(child);
        }
        return bossBattleMovementPoints;
    }

    public float GetBossSpeed()
    {
        return bossSpeed;
    }
    
    public int GetMinRandomNumber()
    {
        return minRandomNumber;
    }
    public int GetMaxRandomNumebr()
    {
        return maxRandomNumber;
    }

    public List<GameObject> GetDrops()
    {
        return drops;
    }
    public float GetDropRate()
    {
        return dropRate;
    }
    public float GetCountDown()
    {
        return dropCountDown;
    }

    public float GetBossShieldLife()
    {
        return shieldLife;
    }
    public bool GetShieldActive()
    {
        return shieldActive;
    }

    public GameObject GetAdditionalGuns(int index)
    {
        return additionalGuns[index];
    }

    public float GetMissileCountDownOne()
    {
        return missileCountDownOne;
    }
    public float GetMissileCountDownTwo()
    {
        return missileCountDownTwo;
    }
    public float GetMissileCountDownThree()
    {
        return missileCountDownThree;
    }

    public bool GetBombOneBool()
    {
        return bombOne;
    }
    public bool GetBombTwoBool()
    {
        return bombTwo;
    }
    public bool GetBombThree()
    {
        return bombThree;
    }


 

    
}

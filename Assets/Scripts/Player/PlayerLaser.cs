using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{

    Rigidbody2D thisRigidbody;
    [Header("Player laser Configs")]
    [SerializeField] float laserSpeed = 500f;
    [SerializeField] float playerLaserDamage = 100f;
    [SerializeField] float bulletFireTime = 1f;

    [Header("Visual Effects")]
    [SerializeField] GameObject laserHitEffect;

    //boundaries
    float yMax;

    //ShieldBreaker
    ShieldBreaker shieldBreaker;
    


    // Start is called before the first frame update
    void Start()
    {
        shieldBreaker = GetComponent<ShieldBreaker>();
        thisRigidbody = GetComponent<Rigidbody2D>();
        MoveLaser();
        
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBoundaries();
        
    }

    private void MoveLaser()
    {
        if (gameObject.name != "PlayerLaser7(Clone)")
        {
            thisRigidbody.AddForce(transform.up * laserSpeed);
        }
    }

    
    private void OutOfBoundaries()
    {
        yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        if(gameObject.transform.position.y > yMax)
        {
            Destroy(gameObject);
        }
    }

    public void Hit()
    {
        //this if is for sniperGun
        if (gameObject.name != "PlayerLaser5(Clone)")
        {
            Destroy(gameObject);
            Vector2 location = new Vector2(transform.position.x, transform.position.y + 0.5f);
            GameObject laserhitEffect = Instantiate(laserHitEffect, location, Quaternion.identity);
            Destroy(laserhitEffect, 2f);
        }
        else if (gameObject.name == "PlayerLaser5(Clone)")
        {
            shieldBreaker.SetEnemyHits();
        }
        
        
        
        
    }

    //Get
    public float GetLaserDamage()
    {
        return playerLaserDamage;
    }

    public float GetFireTime()
    {
         
        return bulletFireTime;
    }

    //For sniperGun
    public GameObject LaserHitEffect()
    {
        return laserHitEffect;
    }



    //SetUp
    public void SetLaserDamage(float damage,PlayerStatus addDamage, BeamLaser beamLaser = null)
    {
        this.playerLaserDamage = damage;
        AddDamage(addDamage.GetAddDamage(), beamLaser);
    }

  

    public void AddDamage(float damage,  BeamLaser beamlaser = null)
    {
        if (beamlaser == null)
        {   
            if(gameObject.name == "PlayerLaser3(Clone)" || gameObject.name == "PlayerLaser6(Clone)" && damage > 800f)
            {
                this.playerLaserDamage += damage * 1.7f;
            }
            else if (gameObject.name == "PlayerLaser4(Clone)" && damage > 800f)
            {
                this.playerLaserDamage += damage - (0.3f * damage);
            }
            else if (gameObject.name == "PlayerLaser1(Clone)" && damage > 900f)
            {
                this.playerLaserDamage += damage - (0.2f * damage);
            }
            else if (gameObject.name == "PlayerLaser2(Clone)" && damage > 900f)
            {
                this.playerLaserDamage += damage - (0.3f * damage);
            }
            else if (gameObject.name == "PlayerLaser5(Clone)")
            {
                this.playerLaserDamage += damage * 1.5f;
            }
            else
            {
                this.playerLaserDamage += damage;
            }
            
        }
        else
        {
            this.playerLaserDamage += damage / 2;
        }
    }

    //For shieldBreaker
    public void SetDamageForShieldBreaker(float damage)
    {
        this.playerLaserDamage = damage;
    }



}

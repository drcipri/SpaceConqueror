using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [Header("Enemy laser configs")]
    [SerializeField] float enemyLaserSpeed = -100f;
    [SerializeField] float enemyLaserDamage = 100;
    [SerializeField] GameObject laserHitEffect;
    [Header("Sound")]
    [SerializeField] SFX sound;
    [SerializeField][Range(0,1)] float soundVolume;
    
    Rigidbody2D thisRigidBody2d;
    

    // Start is called before the first frame update
    void Start()
    {
       
        Laser();
        
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBonds();
    }


    private void Laser()
    {
        
        thisRigidBody2d = GetComponent<Rigidbody2D>();
        thisRigidBody2d.AddForce(transform.up * enemyLaserSpeed);

    }

   

    public void OutOfBonds()
    {
        float yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        if(transform.position.y < yMin)
        {
            Destroy(gameObject);
        }    

    }


    public float GetEnemyLaser()
    {
        return enemyLaserDamage;
    }

    public void Hit()
    {
        AudioSource.PlayClipAtPoint(sound.GetLaserImpact(), Camera.main.transform.position, soundVolume);
        Vector2 location = new Vector2(transform.position.x, transform.position.y + -0.5f );
        GameObject laserhitEffect = Instantiate(laserHitEffect, location, Quaternion.identity);
        Destroy(gameObject);
        Destroy(laserhitEffect, 1f);
    }




}

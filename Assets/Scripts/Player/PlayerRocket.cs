using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocket : MonoBehaviour
{

    [SerializeField] float bombDamage = 500f;
    [SerializeField] float bombSpeed = 5f;
    [SerializeField] GameObject explosionEffect;

    GameObject player;
    GameObject noEnemiesPoint;
    float yMax;
    

    //Find enemy
    GameObject[] enemies;
    Transform closestEnemy = null;
    Transform aimClosestEnemy = null;
    float closestDistance = Mathf.Infinity;
    float currentDistace;
    
    //Sound
    [Header("Sound")]
    [SerializeField]SFX sfx;
    [SerializeField] [Range(0, 1)] float volume = 0.5f;
    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("ThePlayer");
        noEnemiesPoint = player.transform.GetChild(4).gameObject;
    }

  
    private void Update()
    {
        closestEnemy = FindEnemies();
        MoveRocket();
        OutOfBoundaries();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SmallEnemy")
        {
            
            if (collision.TryGetComponent<EnemyStatus>(out EnemyStatus enemyStatus))
            {
                
                enemyStatus.DamageEnemy(bombDamage);
                AudioSource.PlayClipAtPoint(sfx.GetRainBombExplosion(), Camera.main.transform.position, volume);
                GameObject explosion =  Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(explosion, 2f);
                Destroy(gameObject);

            }
            
        }
    }

    private Transform FindEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("SmallEnemy");
        foreach(GameObject enemy in enemies)
        {
            currentDistace = Vector3.Distance(transform.position, enemy.transform.position);
            if (currentDistace < closestDistance)
            {
                closestDistance = currentDistace;
                aimClosestEnemy = enemy.transform;
            }
            
        }
        return aimClosestEnemy;
    }

    private void MoveRocket()
    {
        var moveThisFrame = Time.deltaTime * bombSpeed;
        if(closestEnemy != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, closestEnemy.position, moveThisFrame);
        }
        else if (noEnemiesPoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position,noEnemiesPoint.transform.position, moveThisFrame);
        }
    }

    private void OutOfBoundaries()
    {
        yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        if (gameObject.transform.position.y > yMax)
        {
            Destroy(gameObject);
        }
    }

    public float GetBombDamage()
    {
        return bombDamage;
    }

    public void DestroyThisObject()
    {
        AudioSource.PlayClipAtPoint(sfx.GetRainBombExplosion(), Camera.main.transform.position, volume);
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);
        Destroy(gameObject);
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicBomb : MonoBehaviour
{
    Rigidbody2D thisRigidbody;
    [SerializeField] float rocketSpeed = 500f;
    [SerializeField] float rocketDamage = 20000f;
    [SerializeField] float explosionRadius = 2f;
    [SerializeField] float countDownExplosion = 2f;
    [SerializeField][Range(0,1)] float explosionSound = 0.5f;
    [SerializeField] GameObject flameEffect;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] SFX sfx;
    float yMax;
    Player player;
    BigBombs bigBombs;
    GameObject getPlayer;


    private void Awake()
    {
        getPlayer = GameObject.FindGameObjectWithTag("ThePlayer");
        player = getPlayer.GetComponent<Player>();
        bigBombs = getPlayer.GetComponent<BigBombs>();
        thisRigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MoveRocket();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyRocket();
        OutOfBoundaries();
    }

    private void OutOfBoundaries()
    {
        yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        if (gameObject.transform.position.y > yMax)
        {
            player.SetBeamLaserOnOff(true);
            player.SetStopFireForBigBombs(false);
            Destroy(gameObject);
            bigBombs.SetFinishedLaunching(true);
           
        }
    }

    private void MoveRocket()
    {
        AudioSource.PlayClipAtPoint(sfx.GetRocketLaunch(), Camera.main.transform.position, explosionSound);
        thisRigidbody.AddForce(transform.up * rocketSpeed);
    }

    private void Explosion()
    {
        Collider2D[] explosion = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        GameObject rocektExplosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(rocektExplosion, 3f);
        AudioSource.PlayClipAtPoint(sfx.GetAtomicExplosion(), Camera.main.transform.position, explosionSound);

        foreach (Collider2D objectsFound in explosion)
        {
            if (objectsFound.TryGetComponent<EnemyStatus>(out EnemyStatus enemy))
            {

                enemy.DamageEnemy(rocketDamage);
                Vector2 flamePos = new Vector2(enemy.transform.position.x, enemy.transform.position.y + 0.5f);
                GameObject flame = Instantiate(flameEffect, flamePos, Quaternion.identity);
                Destroy(flame, 2f);

            }
        }




    }

    private void DestroyRocket()
    {
        countDownExplosion -= Time.deltaTime;
        if(countDownExplosion <= 0)
        {
            Explosion();
            player.SetBeamLaserOnOff(true);
            player.SetStopFireForBigBombs(false);
            Destroy(gameObject);
            bigBombs.SetFinishedLaunching(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossBehaviour : MonoBehaviour
{
    [SerializeField]EnemyBossStats bossStats;
    

    //Movement
    EnemyPath entrace;
    List<Transform> movementPoints;
    int movementPointsIndex = 0;
    bool startMoving = true;
    
    //Music
    MusicPlayer musicPlayer;
    bool playMusic = true;


    //Drops
    List<GameObject> dropObjects;
    float countDown;

    //Guns
    float missileCountDownOne;
    float missileCountDownTwo;
    float missileCountDownThree;

    

    

    // Start is called before the first frame update
    void Start()
    {
        
        PlayBossMusic(2);
        missileCountDownOne = bossStats.GetMissileCountDownOne();
        missileCountDownTwo = bossStats.GetMissileCountDownTwo();
        missileCountDownThree = bossStats.GetMissileCountDownThree();


        countDown = bossStats.GetCountDown();
        dropObjects = bossStats.GetDrops();
        movementPoints = bossStats.GetBossBattleMovementPoints();
        entrace = GetComponent<EnemyPath>();

    }

    private void PlayBossMusic(int track)
    {
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<MusicPlayer>();
        if (musicPlayer != null)
        {
            musicPlayer.SetTrackMusic(track);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        BossMovementBehaviour();
        DropBehaviour();
        EnemyBigBombsBehaviour();
       

    }

 

    private void BossMovementBehaviour()
    {
        if (entrace.GetEntraceTruth() == true && startMoving == true) 
        {
            if (playMusic == true)
            {
                PlayBossMusic(1);
                playMusic = false;
            }
            var targetPosition = movementPoints[movementPointsIndex].transform.position;
            var moveThisFrame = Time.deltaTime * bossStats.GetBossSpeed();
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveThisFrame);

            if(transform.position == targetPosition)
            {
                movementPointsIndex = Random.Range(bossStats.GetMinRandomNumber(), bossStats.GetMaxRandomNumebr());
            }
        }

    }

    private void DropBehaviour()
    {
        countDown -= Time.deltaTime;
        
        if (countDown <= 0)
        {
            float dropRate = Random.value;
            int randomItem = Random.Range(0, dropObjects.Count);
            Vector3 dropLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);

            if (dropRate < bossStats.GetDropRate())
            {

                Instantiate(dropObjects[randomItem], dropLocation, Quaternion.identity);
            }
            countDown = bossStats.GetCountDown();

        }
        

    }

    private void EnemyBigBombsBehaviour()
    {
        if (bossStats.GetBombOneBool() == true)
        {
            missileCountDownOne -= Time.deltaTime;
            Vector3 missilePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);

            if (missileCountDownOne <= 0)
            {
                Instantiate(bossStats.GetAdditionalGuns(0), missilePosition, Quaternion.identity);
                missileCountDownOne = bossStats.GetMissileCountDownOne();
      
            }
        }
        if(bossStats.GetBombTwoBool() == true)
        {
            missileCountDownTwo -= Time.deltaTime;
            Vector3 missilePositionOne = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
            Vector3 missilePositionTwo = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z + 2);
            Vector3 missilePositionThree = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z + 2);
            
            if (missileCountDownTwo <= 0)
            {
                Instantiate(bossStats.GetAdditionalGuns(1), missilePositionOne, Quaternion.identity);
                Instantiate(bossStats.GetAdditionalGuns(1), missilePositionTwo, Quaternion.Euler(0, 0, 10f));
                Instantiate(bossStats.GetAdditionalGuns(1), missilePositionThree, Quaternion.Euler(0, 0, -10f));
           
                missileCountDownTwo = bossStats.GetMissileCountDownTwo();
            }
        }
        if(bossStats.GetBombThree() == true)
        {
            missileCountDownThree -= Time.deltaTime;
            Vector3 minePositionOne = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
            Vector3 minePositionTwo = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z + 2);
            Vector3 minePositionThree = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z + 2);
            Vector3 minePositionFour = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 2);
            Vector3 minePositionFive = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z + 2);

            if (missileCountDownThree <= 0)
            {

                Instantiate(bossStats.GetAdditionalGuns(2), minePositionOne, Quaternion.identity);
                Instantiate(bossStats.GetAdditionalGuns(2), minePositionTwo, Quaternion.Euler(0, 0, 10f));
                Instantiate(bossStats.GetAdditionalGuns(2), minePositionThree, Quaternion.Euler(0, 0, -10f));
                Instantiate(bossStats.GetAdditionalGuns(2), minePositionFour, Quaternion.Euler(0, 0, 20f));
                Instantiate(bossStats.GetAdditionalGuns(2), minePositionFive, Quaternion.Euler(0, 0, -20f));
                missileCountDownThree = bossStats.GetMissileCountDownThree();
            }
        }
    }

    


}

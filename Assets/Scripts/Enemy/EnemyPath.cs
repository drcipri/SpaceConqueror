using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    WaveConfig waveConfig;
    EnemySpawner enemySpawner;
    GameObject findEnemySpawner;
 

    List<Transform> wayPoints;
    int wayPointsIndex = 0;
    int enemyPlace;

    //For EnemyBOSS
    bool movementEntrace = false;


    private void Awake()
    {
        findEnemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
    }

    private void Start()
    {
        enemySpawner = findEnemySpawner.GetComponent<EnemySpawner>();
        enemyPlace = enemySpawner.GetEnemyPlace();
        wayPoints = waveConfig.GetWayPoints();
        

    }

    private void Update()
    {
        
        EnemyMovement();
        
        

    }

    private void EnemyMovement()
    {

        if (transform.position != wayPoints[enemyPlace].transform.position && movementEntrace == false)
        {
            
            var targetPosition = wayPoints[wayPointsIndex].transform.position;
            var moveThisFrame = Time.deltaTime * waveConfig.GetEnemySpeed();
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveThisFrame);
            
            if(transform.position == wayPoints[enemyPlace].transform.position)
            {
                movementEntrace = true;
            }
          

            if (targetPosition == transform.position)
            {

                wayPointsIndex++;
                if (transform.position == wayPoints[waveConfig.GetEnemyMovingPoints()].transform.position)
                {
                   wayPointsIndex = enemyPlace;
                    
                }
                   

            }
            
        }
       
    }

    

    public void SetUpWave(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }


    //for enemy Boss
    public bool GetEntraceTruth()
    {
        return movementEntrace;
    }

  

  

   



}

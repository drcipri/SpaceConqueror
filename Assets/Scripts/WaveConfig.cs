using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Configuration")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] int numbersOfEnemiesType1;
    [SerializeField] int numbersOfEnemiesType2;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawn = 1f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float enemySpeed = 1f;
    [SerializeField] int movingPoints = 0;
    
    

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefab[index];
    }
    public List<Transform> GetWayPoints()
    {
        var waveWayPoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }
    public float GetTimeBetweenSpawn()
    {
        return timeBetweenSpawn;
    }
 
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetEnemySpeed()
    {
        return enemySpeed;
    }

    public int GetEnemyMovingPoints()
    {
        return movingPoints;
    }

    //Set
    public void SetEnemyMovingPoints(int place)
    {
        this.movingPoints += place;
    }

    public int GetNumbersOfType1()
    {
        return numbersOfEnemiesType1;
    }
    public int GetNumbersOfType2()
    {
        return numbersOfEnemiesType2;
    }


}

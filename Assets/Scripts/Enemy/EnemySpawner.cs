using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Change what you want but DO NOT OVERRIDE ENEMY SPAWNER PREFAB")]
    [SerializeField] ManageScene manageScene;
    [SerializeField] int whatLevelIsThis = 0;
    [SerializeField]List <WaveConfig> waveConfigs;
    [SerializeField]int startingWave = 0;
    [SerializeField] float timeBetweenWaves = 0.5f;
    float copyCountdown;
    bool waveDeath = false;
    bool lastWave = false;

    float movingPlayerCountDown = 3f;
    int enemyPlace;
    Player player;
    BigBombs bigBombs;
    GameObject getPlayer;
    
    ButtonsManager buttonsManager;
    GameObject canvas;
    GameObject radar;

    float winLevelCountDown = 3f;

    
    int enemies = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
        radar = GameObject.FindGameObjectWithTag("Radar");

        buttonsManager = GameObject.FindGameObjectWithTag("ButtonManager").GetComponent<ButtonsManager>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");

        getPlayer = GameObject.FindGameObjectWithTag("ThePlayer");
        player = getPlayer.GetComponent<Player>();
        bigBombs = getPlayer.GetComponent<BigBombs>();
        copyCountdown = timeBetweenWaves;

    }

 

    // Update is called once per frame
    void Update()
    {

        SpawnEnemies();


    }

   private void SpawnEnemies()
    {
        if (enemies == 0 && startingWave < waveConfigs.Count && player.GetMovingPlayerAtStart() == false )
        {
            timeBetweenWaves -= Time.deltaTime;
            if (timeBetweenWaves <= 0)
            {

                waveDeath = true;
                StartCoroutine(SpawnALLWaves());
                timeBetweenWaves = copyCountdown;


            }
        }
        else if (buttonsManager.GetPlayerDeath() == false && enemies == 0 && startingWave == waveConfigs.Count && lastWave == true)
        {
            movingPlayerCountDown -= Time.deltaTime;
            if (movingPlayerCountDown <= 0f)
            {
                player.SetStopPlayerFromMoving(true);
                if (player.GetLaser().name == "PlayerLaser7")
                {
                    player.SetBeamLaserOnOff(false);
                }
                player.SetStopFireForBigBombs(true);
                canvas.transform.GetChild(6).gameObject.SetActive(false);
                canvas.transform.GetChild(7).gameObject.SetActive(false);
                winLevelCountDown -= Time.deltaTime;
                if (winLevelCountDown <= 0 && bigBombs.GetFinishedLaunching() == true)
                {
                    player.SetIWonLevel(true);
                    winLevelCountDown = 2f;
                }
                if (player.GetWinLevel() == true)
                {
                    buttonsManager.SetWinLevel(true);
                    manageScene.SetLevelsCleared(whatLevelIsThis);
                    SaveSystem.SaveScenes(manageScene);

                }
            }
            
        }
    }

    IEnumerator SpawnALLWaves()
    {
        
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; )
        {
            
            var currentWave = waveConfigs[waveIndex];
            if (startingWave != waveConfigs.Count)
            {
                startingWave++;
                enemyPlace = currentWave.GetEnemyMovingPoints();

            }
            
            StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            radar.transform.GetChild(0).gameObject.SetActive(true);
            waveDeath = false;
            yield return new WaitUntil(() => waveDeath == true);
            
            
        }
    }

    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemy = 1; enemy <= waveConfig.GetNumberOfEnemies(); enemy++)
        {

            
            if (enemy <= waveConfig.GetNumbersOfType1())
            {
                var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(0),
                    waveConfig.GetWayPoints()[0].transform.position,
                    Quaternion.identity);
                newEnemy.GetComponent<EnemyPath>().SetUpWave(waveConfig);
            }
            else if ( enemy > waveConfig.GetNumbersOfType1() && enemy <= waveConfig.GetNumbersOfType2())
            {
                var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(1),
                    waveConfig.GetWayPoints()[0].transform.position,
                    Quaternion.identity);
                newEnemy.GetComponent<EnemyPath>().SetUpWave(waveConfig);
            }
            else//instatiate 3rd type
            {
                var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(2),
                    waveConfig.GetWayPoints()[0].transform.position,
                    Quaternion.identity);
                newEnemy.GetComponent<EnemyPath>().SetUpWave(waveConfig);
            }
            
            if(enemy == waveConfig.GetNumberOfEnemies() && startingWave == waveConfigs.Count)
            {
                lastWave = true;
            }

            if(enemy == 1)
            {
                enemies = waveConfig.GetNumberOfEnemies();
            }
            enemyPlace += 1;
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawn());
        }
    }

    
    public void SetNumberOfDeadEnemies(int enemies)
    {
        this.enemies -= enemies;
    }

    public int GetEnemyPlace()
    {
        return enemyPlace;
    }


    //for respawning player
    public void SetUpStartingWave(int wave)
    {
        this.startingWave = wave;
    }

    public int GetStartingWave()
    {
        return startingWave;
    }
  
}

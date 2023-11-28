using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    
    //boundaries
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    float cameraHeight = 0f;//For performance

    //Sprite
    SpriteRenderer playerSprite;
    float spriteHalfWidth;
    float spriteHalfHeight;

    //Shooting
   [Header("Player Shooting")]
   [SerializeField]GameObject playerGun;
   [SerializeField] bool gunFire = false;
    bool stopFire = false;
    bool beamLaser = true;


    //moving Player
    [Header("Moving Player")]
    [SerializeField] float playerTouchSpeed = 100f;
    [SerializeField] GameObject playerStartWayPoints;
    [SerializeField] GameObject playerWinWayPoints;
    [SerializeField] [Range(0,20)]float playerMovingSpeed = 10f;
    [SerializeField] [Range(0, 40)] float playerMovingSpeedAfterBeatingBoss = 10f;
    [SerializeField]bool movingPlayer = true;
    bool stopPlayerFromMoving = false;
    int playerWayPointsIndex = 0;
    int playerWayPointsIndexWin = 0;
    float yMax2;
    bool winLevel = false;
    bool iWonLevel = false;
    
    
    //SFX
    [Header("Sounds")]
    [SerializeField] SFX sounds;
    float volume2 = 10f;

    //for buttons
    ButtonInteract pauseButton;
    ButtonInteract bigBombButton;

    

    private void Start()
    {
        bigBombButton = GameObject.FindGameObjectWithTag("BigBombButton").GetComponent<ButtonInteract>();
        pauseButton = GameObject.FindGameObjectWithTag("PauseButton").GetComponent<ButtonInteract>();
        StartCoroutine(Shooting());
    }

    private void Update()
    {
        SetUpPlaySpaceBoundaries();
        if (movingPlayer == true && stopPlayerFromMoving == false )
        {
            MovingPlayerAtStart(GetPlayerWayPoints());
        }
        else if (movingPlayer == false && stopPlayerFromMoving == false)
        {
            Movement();
        }
        else if (iWonLevel == true)
        {
            MovePlayerIfWinTheLevel(GetPlayerWayPoints2());
        }
        
        
    }

  

    //movement method
    private void Movement()
    {

        
        if (Input.touchCount > 0 && pauseButton.GetButtonPressed() == false && bigBombButton.GetButtonPressed() == false)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            touchPosition.y += 1.7f;
            var xPos = Mathf.Clamp(touchPosition.x, xMin, xMax);
            var yPos = Mathf.Clamp(touchPosition.y, yMin, yMax);
            Vector2 playerMoving = new Vector2(xPos, yPos);
            var moveThisFrame = Time.deltaTime * playerTouchSpeed;
            transform.position = Vector2.MoveTowards(transform.position, playerMoving, moveThisFrame);
            
            
        }
        
        
    }

    //boundaries  method
    private void SetUpPlaySpaceBoundaries()
    {
        if (cameraHeight != Camera.main.orthographicSize)
        {
            cameraHeight = Camera.main.orthographicSize;

            playerSprite = GetComponent<SpriteRenderer>();
            spriteHalfWidth = playerSprite.bounds.size.x / 2;
            spriteHalfHeight = playerSprite.bounds.size.y / 2;


            Camera gameCamera = Camera.main;
            xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + spriteHalfWidth;
            xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - spriteHalfWidth;
            yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + spriteHalfHeight;
            yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - spriteHalfHeight;
            
        }
    }

    //shooting method
   IEnumerator Shooting()
   {
        while (true)
        {
            PlayerLaser getFireTime = playerGun.GetComponent<PlayerLaser>();
            if (gunFire == true && stopFire == false)
            {
                GetPlayerGun();
                      
            }
            yield return new WaitForSeconds(getFireTime.GetFireTime());
        }

    }

    private void GetPlayerGun()
    {
        UpgradePlayerGun gun = GetComponent<UpgradePlayerGun>();
        if (playerGun.name == "PlayerLaser1")
        {
            gun.StraightGun();
        }
        else if (playerGun.name == "PlayerLaser2")
        {
            gun.ShotGun();
        }
        else if (playerGun.name == "PlayerLaser3")
        {
            gun.GrenadeGun();
        }
        else if (playerGun.name == "PlayerLaser4")
        {
            gun.TommyGun();
        }
        else if(playerGun.name == "PlayerLaser5")
        {
            gun.SniperGun();
        }
        else if(playerGun.name == "PlayerLaser6")
        {
            gun.ZapGun();
        }
        else if (playerGun.name == "PlayerLaser7")
        {
            GunFire(false);
            beamLaser = true;
            gun.LaserBeamGun();
            
        }

    }



    //for UpgradePlayerGunClass
    public GameObject GetLaser()
    {
        GameObject laser = playerGun;
        return laser;
    }

   

    public void SetUpPlayerGun(GameObject playerGun)
    {
        this.playerGun = playerGun;
    }



    //Set up gunFire
    public void GunFire(bool gunFire)
    {
        this.gunFire = gunFire;
    }


    //for beam laser
    public void SetBeamLaserOnOff(bool beamLaser)
    {
        this.beamLaser = beamLaser;
    }

    public bool GetBeamLaserOnOff()
    {
        return beamLaser;
    }

    //for big bombs
    public void SetStopFireForBigBombs(bool stopFire)
    {
        this.stopFire = stopFire;
    }

    public bool GetStopFireForBigBombs()
    {
        return stopFire;
    }

    //move Player
    private void MovingPlayerAtStart(List<Transform> getPlayerWayPoints)
    {
        
        GameObject playerSpeedObject = gameObject.transform.GetChild(2).gameObject;
        playerSpeedObject.GetComponent<PlayerSpeedEffect>().SetObjectActive(true);
        
        var targetPosition = getPlayerWayPoints[playerWayPointsIndex].transform.position;
        var movingSpeed = Time.deltaTime * playerMovingSpeed;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movingSpeed);
        
        if (transform.position == targetPosition)
        {

            if (transform.position == getPlayerWayPoints[1].transform.position)
            {
                playerSpeedObject.GetComponent<PlayerSpeedEffect>().SetObjectActive(false);
                GunFire(true);
                movingPlayer = false;
            }
            else
            {
                AudioSource.PlayClipAtPoint(sounds.GetEngagingEnemy(), Camera.main.transform.position, volume2);

                playerWayPointsIndex++;
                playerMovingSpeed -= 8f;
            }
        }
    }

    private void MovePlayerIfWinTheLevel(List<Transform> getPlayerWayPoints)
    {
        GameObject playerSpeedObject = gameObject.transform.GetChild(2).gameObject;
        playerSpeedObject.GetComponent<PlayerSpeedEffect>().SetObjectActive(true);
        var targetPosition = getPlayerWayPoints[playerWayPointsIndexWin].transform.position;
        var movingSpeed = Time.deltaTime * playerMovingSpeedAfterBeatingBoss;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movingSpeed);
        OutOfBoundaries();

    }
    private void OutOfBoundaries()
    {
        yMax2 = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        if (gameObject.transform.position.y > yMax2)
        {
            winLevel = true;
        }
    }

    //set moving player // use this if you want to stop moving the player from code
    public void SetStopPlayerFromMoving(bool stopPlayer)
    {
        this.stopPlayerFromMoving = stopPlayer;
    }

    public void SetIWonLevel(bool iWonLevel)
    {
        this.iWonLevel = iWonLevel;
        AudioSource.PlayClipAtPoint(sounds.GetTargetAquired(), Camera.main.transform.position, volume2);
    }

    //get 

    public bool GetIWonLevel()
    {
        return iWonLevel; 
    }
    public bool GetGunFireTruth()
    {
        return gunFire;
    }

    public bool GetMovingPlayerAtStart()
    {
        return movingPlayer;
    }

    public bool GetWinLevel()
    {
        return winLevel;
    }


    //WayPoints of Player
    private List<Transform> GetPlayerWayPoints()
    {
        var wayPoints = new List<Transform>();
        foreach(Transform child in playerStartWayPoints.transform)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
    private List<Transform> GetPlayerWayPoints2()
    {
        var wayPoints = new List<Transform>();
        foreach (Transform child in playerWinWayPoints.transform)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }







}

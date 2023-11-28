using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigBombButton : MonoBehaviour
{
    GameObject bombRain;
    GameObject bombAtomic;
    GameObject bombLaser;



    GameObject player;
    Button button;
    Player thePlayer;
    BigBombs bigBombs;

   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("ThePlayer");
        thePlayer = player.GetComponent<Player>();
        bigBombs = player.GetComponent<BigBombs>();

        button = GetComponent<Button>();
        bombRain = gameObject.transform.GetChild(0).gameObject;
        bombAtomic = gameObject.transform.GetChild(1).gameObject;
        bombLaser = gameObject.transform.GetChild(2).gameObject;
        button.onClick.AddListener(CheckButton);
    }

    private void CheckButton()
    {
        bool rain = gameObject.transform.GetChild(0).gameObject.activeSelf;
        bool atomic = gameObject.transform.GetChild(1).gameObject.activeSelf;
        bool laser = gameObject.transform.GetChild(2).gameObject.activeSelf;
        if(rain == true)
        {
            BigBombRain();
        }
        else if(atomic == true)
        {
            BigBombAtomic();
        }
        else if(laser == true)
        {
            BigBombLaser();
        }
    }
 
    private void BigBombRain()
    {
        if (bombRain.activeSelf == true && thePlayer.GetStopFireForBigBombs() == false)
        {
        
            bombRain.SetActive(false);

            if (thePlayer.GetLaser().name == "PlayerLaser7")
            {
                thePlayer.SetBeamLaserOnOff(false);
            }

            thePlayer.SetStopFireForBigBombs(true);
            bigBombs.SetFireBigBomb(true);
            bigBombs.SetFireBigBombRain(true);
        }

    }

    private void BigBombAtomic()
    {
        if (bombAtomic.activeSelf == true && thePlayer.GetStopFireForBigBombs() == false)
        {

            bombAtomic.SetActive(false);

            if (thePlayer.GetLaser().name == "PlayerLaser7")
            {
                thePlayer.SetBeamLaserOnOff(false);
            }

            thePlayer.SetStopFireForBigBombs(true);
            bigBombs.SetFireBigBomb(true);
            bigBombs.SetFireBigBombAtomic(true);
        }
    }

    private void BigBombLaser()
    {
        if (bombLaser.activeSelf == true && thePlayer.GetStopFireForBigBombs() == false)
        {

            bombLaser.SetActive(false);

            if (thePlayer.GetLaser().name == "PlayerLaser7")
            {
                thePlayer.SetBeamLaserOnOff(false);
            }

            thePlayer.SetStopFireForBigBombs(true);
            bigBombs.SetFireBigBomb(true);
            bigBombs.SetFireBigBombLaser(true);
        }
    }






    
}

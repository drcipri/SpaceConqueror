using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Armor : MonoBehaviour
{
    //ForCalculation
    float percentage = 0f;
    GameObject thePlayer;
    PlayerShield playerShield;
    PlayerStatus playerStatus;


    float mainShieldNumber;
    float realTimeShield;
    float dividedDecimal;

    //for display
    Text text;

    


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("ThePlayer");
        playerShield = thePlayer.transform.GetChild(1).GetComponent<PlayerShield>();
        playerStatus = thePlayer.GetComponent<PlayerStatus>();
        mainShieldNumber = playerStatus.GetPlayerStatsShield();

        text = gameObject.transform.GetChild(1).GetComponent<Text>();
        

    }

    // Update is called once per frame
    void Update()
    {
        CalculatePercentage();
        DisplayArmorPercentage();
        
    }

    private void DisplayArmorPercentage()
    {
        text.text = percentage.ToString("F1") + "%";
    }

    private void CalculatePercentage()
    {

        if (playerShield != null)
        {

            if (playerShield.isActiveAndEnabled)
            {
                realTimeShield = playerShield.GetShield();
                dividedDecimal = realTimeShield / mainShieldNumber;
                percentage = dividedDecimal * 100;

            }
            else
            {
                percentage = 0f;
            }

        }
        else
        {
            percentage = 0f;
        }

    }
    
}

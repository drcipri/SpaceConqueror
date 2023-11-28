using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PayToRestart : MonoBehaviour
{
    [SerializeField] Crystals crystals;
    [SerializeField] CrystalData crystalsData;
    [SerializeField] RestartWave restartWave;
    [SerializeField] PlayerChoser spaceshipPlayer;
    GameObject youDontHaveMoney;
    GameObject watchAdWindow;
    Text buttonText;
    int tier1 = 1000;
    int tier2 = 1500;
    int tier3 = 2000;
    int tier4 = 2500;
    int tier5 = 3000;
    int price;

    private void Start()
    {
        youDontHaveMoney = gameObject.transform.parent.GetChild(4).gameObject;
        watchAdWindow = gameObject.transform.parent.gameObject;
        SetPrice();
    }
    private void SetPrice()
    {
        buttonText = gameObject.transform.GetChild(0).GetComponent<Text>();
        if (spaceshipPlayer.GetPlayerShip().name == "Player1" || spaceshipPlayer.GetPlayerShip().name == "Player2"
            || spaceshipPlayer.GetPlayerShip().name == "Player3")
        {
            price = tier1;
            buttonText.text = price.ToString();
            
        }
        else if((spaceshipPlayer.GetPlayerShip().name == "Player4" || spaceshipPlayer.GetPlayerShip().name == "Player5"
            || spaceshipPlayer.GetPlayerShip().name == "Player6"))
        {
            price = tier2;
            buttonText.text = price.ToString();
        }
        else if ((spaceshipPlayer.GetPlayerShip().name == "Player7" || spaceshipPlayer.GetPlayerShip().name == "Player8"
            || spaceshipPlayer.GetPlayerShip().name == "Player9"))
        {
            price = tier3;
            buttonText.text = price.ToString();
        }
        else if ((spaceshipPlayer.GetPlayerShip().name == "Player10" || spaceshipPlayer.GetPlayerShip().name == "Player11"
            || spaceshipPlayer.GetPlayerShip().name == "Player12"))
        {
            price = tier4;
            buttonText.text = price.ToString();
        }
        else if ((spaceshipPlayer.GetPlayerShip().name == "Player13" || spaceshipPlayer.GetPlayerShip().name == "Player14"
            || spaceshipPlayer.GetPlayerShip().name == "Player15"))
        {
            price = tier5;
            buttonText.text = price.ToString();
        }
    }

    public void CheckMoneyAndPay()
    {
        if(crystalsData.GetCrystals() >= price)
        {
            crystals.GiveCrystals(price);
            watchAdWindow.SetActive(false);
            restartWave.RestartWaveForWatchingAds();
        }
        else
        {
            youDontHaveMoney.SetActive(true);
        }
    }

    public void CloseNoMoneyWindow()
    {
        youDontHaveMoney.SetActive(false);
    }

    
}

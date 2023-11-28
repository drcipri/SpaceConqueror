using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyShip : MonoBehaviour
{
    [Header("Needs")]
    [SerializeField] int shipPrice = 1000;
    [SerializeField] PlayerStats playerStats;

    [Header("Windows")]
    [SerializeField] GameObject confirmButton;
    [SerializeField] GameObject upgradeWindow;
    [SerializeField] GameObject buyShipWindow;
    [SerializeField] GameObject confirmWindow;
    [SerializeField] GameObject youDontHaveMoneyWindow;
    [SerializeField] GameObject shipImage;
    [SerializeField] GameObject shipPanelPrice;

    [Header("Texts")]
    [SerializeField] Text priceText;
    [SerializeField] Text confirmWindowText;
    [SerializeField] Text youDonthaveMoneyText;

    [Header("Money")]
    [SerializeField] Crystals crystals;
    [SerializeField] CrystalData crystalData;

    [Header("Sfx")]
    [SerializeField] SFX sfx;
    float volume = 10f;


    private void Awake()
    {
        IfShipIsAquired();
    }
    private void Start()
    {
        priceText.text = shipPrice.ToString();
    }


    public void CheckMoney()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        if (crystalData.GetCrystals() >= shipPrice)
        {
            confirmWindowText.text = "Buy this ship for " + shipPrice.ToString() + " crystals !";
            confirmWindow.SetActive(true);
        }
        else
        {
            youDonthaveMoneyText.text = "You need " + shipPrice.ToString() + " crystals !";
            youDontHaveMoneyWindow.SetActive(true);    
        }

    }

    public void NoBuy()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        confirmWindow.SetActive(false);
    }

    public void BuyTheShip()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        playerStats.SetIfShipIsBought(true);
        SaveSystem.SaveUpgrades(playerStats);
        crystals.GiveCrystals(shipPrice);
        confirmButton.SetActive(true);
        upgradeWindow.SetActive(true);
        buyShipWindow.SetActive(false);
        shipImage.GetComponent<Image>().color = Color.white;
        shipPanelPrice.SetActive(false);
    }

    public void IfShipIsAquired()
    {
        if (playerStats.GetIfShipIsBought() == true)
        {
            confirmButton.SetActive(true);
            upgradeWindow.SetActive(true);
            buyShipWindow.SetActive(false);
        }
    }


}

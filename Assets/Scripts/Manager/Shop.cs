using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] Crystals crystals;
    [SerializeField] GameObject infoWindow;
    [SerializeField] Text infoAboutPurchase;
    [SerializeField] FreePlay freePlay;
    [SerializeField] GameObject restoreButton;

    private const string firstProductID = "com.cotunastudio.spaceconqueror.crystalpackone";
    private const string secondProductID = "com.cotunastudio.spaceconqueror.crystalpacktwo";
    private const string thirdProductID = "com.cotunastudio.spaceconqueror.crystalpackthree";
    private const string fourthProductID = "com.cotunastudio.spaceconqueror.freeplay";

    private void Awake()
    {
        if(Application.platform != RuntimePlatform.IPhonePlayer)
        {
            restoreButton.SetActive(false);
        }

    }
    public void OnPurchaseCompleteConsumable(Product product)
    {
        if(product.definition.id  == firstProductID)
        {
            crystals.SetUpCrystals(10000);
            infoAboutPurchase.text = "You bought 10.000 crystals! Enjoy!";
            infoWindow.SetActive(true);
        }
        else if (product.definition.id == secondProductID)
        {
            crystals.SetUpCrystals(25000);
            infoAboutPurchase.text = "You bought 25.000 crystals! Enjoy!";
            infoWindow.SetActive(true);
        }
        else if(product.definition.id == thirdProductID)
        {
            crystals.SetUpCrystals(38000);
            infoAboutPurchase.text = "You bought 38.000 crystals! Enjoy!";
            infoWindow.SetActive(true);
        }
        
    }
    public void OnPurchaseCompleteNonConsumable(Product product)
    {
         if (product.definition.id == fourthProductID)
         {
            freePlay.SetFreePlay(true);
            SaveSystem.SaveFreePlay(freePlay);
            infoAboutPurchase.text = "You bought insurance for your spaceships! You can restart now any enemy waves for free!";
            infoWindow.SetActive(true);
         }
    }


    public void OnPurchaseFailed(Product product ,PurchaseFailureReason reason)
    {
        infoAboutPurchase.text = $"Purchase failed because: {reason} !";
        infoWindow.SetActive(true);

    }

 
}

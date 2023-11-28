using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShip : MonoBehaviour
{
    [SerializeField]PlayerStats playerStats;
    [SerializeField] SFX sfx;

    float volume = 10f;
    [SerializeField] GameObject payWindowAttack;
    [SerializeField] GameObject payWindowAttackText;
    [SerializeField] GameObject payWindowShield;
    [SerializeField] GameObject payWindowShieldText;
    [SerializeField] GameObject payWindowHealth;
    [SerializeField] GameObject payWindowHealthText;
    //errors
    [SerializeField] GameObject upgradeIsFull;
    [SerializeField] GameObject youDontHaveMoney;
    [SerializeField] GameObject youDontHaveMoneyText;
    
    [Header("Money")]
    [SerializeField] Crystals crystals;
    [SerializeField] CrystalData crystalsData;

    [Header("UpgradeLevel")]
    [SerializeField] GameObject upgradeAttackLevel1;
    [SerializeField] GameObject upgradeAttackLevel2;
    [SerializeField] GameObject upgradeAttackLevel3;
    [SerializeField] GameObject upgradeShieldLevel1;
    [SerializeField] GameObject upgradeShieldLevel2;
    [SerializeField] GameObject upgradeShieldLevel3;
    [SerializeField] GameObject upgradeHealthLevel1;
    [SerializeField] GameObject upgradeHealthLevel2;
    [SerializeField] GameObject upgradeHealthLevel3;
    [Header("Upgrade Proprety")]
    [SerializeField] float attack = 0f;
    [SerializeField] float shield = 0f;
    [SerializeField] float health = 0f;

    [Header("Upgrade Price")]
    [SerializeField] int attackPrice = 0;
    [SerializeField] int shieldPrice = 0;
    [SerializeField] int healthPrice = 0;

    





    private void Start()
    {
        SetUpgradeAttackColors();
        SetUpgradeShieldColors();
        SetUpgradeHealthColors();
    }


    //attack
    public void CheckMoneyForAttackUpgrade()
    {
        
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        if (crystalsData.GetCrystals() >= attackPrice)
        {
            
            payWindowAttackText.GetComponent<Text>().text = "This action will cost " + attackPrice.ToString() + " crystals. Proceed?";
            payWindowAttack.SetActive(true);
        }
        else
        {
            youDontHaveMoneyText.GetComponent<Text>().text = "You need " + attackPrice.ToString() + " crystals !";
            youDontHaveMoney.SetActive(true);
        }
    }
   
    public void UpgradeAttackBonus()
    {
        
        if(playerStats.GetUpgradeAttackLevel() < 3)
        {
            payWindowAttack.SetActive(false);
            crystals.GiveCrystals(attackPrice);
            AudioSource.PlayClipAtPoint(sfx.GetAttackUpgrade(), Camera.main.transform.position, volume);
            playerStats.UpgradeAttackBonus(attack);
            if(playerStats.GetUpgradeAttackLevel() == 1)
            {
                upgradeAttackLevel1.GetComponent<Image>().color = Color.red;
            }
            else if(playerStats.GetUpgradeAttackLevel() == 2)
            {
                upgradeAttackLevel2.GetComponent<Image>().color = Color.red;
            }
            else if(playerStats.GetUpgradeAttackLevel() == 3)
            {
                upgradeAttackLevel3.GetComponent<Image>().color = Color.red;
            }
            SaveSystem.SaveUpgrades(playerStats);
            
        }
        else
        {
            payWindowAttack.SetActive(false);
            upgradeIsFull.SetActive(true);
        }
    }

    public void SetUpgradeAttackColors()
    {
        if (playerStats.GetUpgradeAttackLevel() == 1)
        {
            upgradeAttackLevel1.GetComponent<Image>().color = Color.red;
        }
        else if (playerStats.GetUpgradeAttackLevel() == 2)
        {
            upgradeAttackLevel1.GetComponent<Image>().color = Color.red;
            upgradeAttackLevel2.GetComponent<Image>().color = Color.red;
        }
        else if (playerStats.GetUpgradeAttackLevel() == 3)
        {
            upgradeAttackLevel1.GetComponent<Image>().color = Color.red;
            upgradeAttackLevel2.GetComponent<Image>().color = Color.red;
            upgradeAttackLevel3.GetComponent<Image>().color = Color.red;
        }
    }


    //shield
    public void CheckMoneyForShieldUpgrade()
    {

        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        if (crystalsData.GetCrystals() >= shieldPrice)
        {

            payWindowShieldText.GetComponent<Text>().text = "This action will cost " + shieldPrice.ToString() + " crystals. Proceed?";
            payWindowShield.SetActive(true);
        }
        else
        {
            youDontHaveMoneyText.GetComponent<Text>().text = "You need " + shieldPrice.ToString() + " crystals !";
            youDontHaveMoney.SetActive(true);
        }
    }
    public void UpgradeShield()
    {

        if (playerStats.GetUpgradeShieldLevel() < 3)
        {
            payWindowShield.SetActive(false);
            crystals.GiveCrystals(shieldPrice);
            AudioSource.PlayClipAtPoint(sfx.GetShieldUpgrade(), Camera.main.transform.position, volume);
            playerStats.UpgradeShield(shield);
            if (playerStats.GetUpgradeShieldLevel() == 1)
            {
                upgradeShieldLevel1.GetComponent<Image>().color = Color.yellow;
            }
            else if (playerStats.GetUpgradeShieldLevel() == 2)
            {
                upgradeShieldLevel2.GetComponent<Image>().color = Color.yellow;
            }
            else if (playerStats.GetUpgradeShieldLevel() == 3)
            {
                upgradeShieldLevel3.GetComponent<Image>().color = Color.yellow;
            }
            SaveSystem.SaveUpgrades(playerStats);

        }
        else
        {
            payWindowShield.SetActive(false);
            upgradeIsFull.SetActive(true);
        }
    }
    public void SetUpgradeShieldColors()
    {
        if (playerStats.GetUpgradeShieldLevel() == 1)
        {
            upgradeShieldLevel1.GetComponent<Image>().color = Color.yellow;
        }
        else if (playerStats.GetUpgradeShieldLevel() == 2)
        {
            upgradeShieldLevel1.GetComponent<Image>().color = Color.yellow;
            upgradeShieldLevel2.GetComponent<Image>().color = Color.yellow;
        }
        else if (playerStats.GetUpgradeShieldLevel() == 3)
        {
            upgradeShieldLevel1.GetComponent<Image>().color = Color.yellow;
            upgradeShieldLevel2.GetComponent<Image>().color = Color.yellow;
            upgradeShieldLevel3.GetComponent<Image>().color = Color.yellow;
            
        }
    }

    //Health
    public void CheckMoneyForHealthUpgrade()
    {

        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        if (crystalsData.GetCrystals() >= healthPrice)
        {

            payWindowHealthText.GetComponent<Text>().text = "This action will cost " + healthPrice.ToString() + " crystals. Proceed?";
            payWindowHealth.SetActive(true);
        }
        else
        {
            youDontHaveMoneyText.GetComponent<Text>().text = "You need " + healthPrice.ToString() + " crystals !";
            youDontHaveMoney.SetActive(true);
        }
    }

    public void UpgradeHealth()
    {

        if (playerStats.GetUpgradeHealthLevel() < 3)
        {
            payWindowHealth.SetActive(false);
            crystals.GiveCrystals(healthPrice);
            AudioSource.PlayClipAtPoint(sfx.GetLifeUpgrade(), Camera.main.transform.position, volume);
            playerStats.UpgradeHealth(health);
            if (playerStats.GetUpgradeHealthLevel() == 1)
            {
                upgradeHealthLevel1.GetComponent<Image>().color = Color.green;
            }
            else if (playerStats.GetUpgradeHealthLevel() == 2)
            {
                upgradeHealthLevel2.GetComponent<Image>().color = Color.green;
            }
            else if (playerStats.GetUpgradeHealthLevel() == 3)
            {
                upgradeHealthLevel3.GetComponent<Image>().color = Color.green;
            }
            SaveSystem.SaveUpgrades(playerStats);

        }
        else
        {
            payWindowHealth.SetActive(false);
            upgradeIsFull.SetActive(true);
        }
    }

    public void SetUpgradeHealthColors()
    {
        if (playerStats.GetUpgradeHealthLevel() == 1)
        {
            upgradeHealthLevel1.GetComponent<Image>().color = Color.green;
        }
        else if (playerStats.GetUpgradeHealthLevel() == 2)
        {
            upgradeHealthLevel1.GetComponent<Image>().color = Color.green;
            upgradeHealthLevel2.GetComponent<Image>().color = Color.green;
        }
        else if (playerStats.GetUpgradeHealthLevel() == 3)
        {
            upgradeHealthLevel1.GetComponent<Image>().color = Color.green;
            upgradeHealthLevel2.GetComponent<Image>().color = Color.green;
            upgradeHealthLevel3.GetComponent<Image>().color = Color.green;

        }
    }


}

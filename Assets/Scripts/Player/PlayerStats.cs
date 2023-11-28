using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [Header("Stats")]
    [SerializeField] float playerHealth = 0f;
    [SerializeField] float bonusDamage = 0f;
    [SerializeField] float shield = 0f;
    [Header("UpgradeLevel")]
    [SerializeField]int upgradeHealthLevel = 0;
    [SerializeField]int upgradeDamageLevel = 0;
    [SerializeField] int upgradeShieldLevel = 0;
    [Header("Is ship bought")]
    [SerializeField] bool shipAquired = false;


    //ship aquired
    public bool GetIfShipIsBought()
    {
        return shipAquired;
    }

    public void SetIfShipIsBought(bool shipAquired)
    {
        this.shipAquired = shipAquired;
    }

    //attack
    public void UpgradeAttackBonus(float bonusDamage)
    {
        if(upgradeDamageLevel < 3)
        {
            this.bonusDamage += bonusDamage;
            upgradeDamageLevel++;
        }
    }
    public int GetUpgradeAttackLevel()
    {
        return upgradeDamageLevel;
    }


    //shield
    public void UpgradeShield(float shield)
    {
        if (upgradeShieldLevel < 3)
        {
            this.shield += shield;
            upgradeShieldLevel++;
        }
    }
    public int GetUpgradeShieldLevel()
    {
        return upgradeShieldLevel;
    }
    //health
    public void UpgradeHealth(float playerHealth)
    {
        if (upgradeHealthLevel < 3)
        {
            this.playerHealth += playerHealth;
            upgradeHealthLevel++;
        }
    }
    public int GetUpgradeHealthLevel()
    {
        return upgradeHealthLevel;
    }
    //manager
    public float GetPlayerHealth()
    {
        return playerHealth;
    }

    public float GetBonusDamage()
    {
        return bonusDamage;
    }

    public float GetPlayerShield()
    {
        return shield;
    }

  //ForLoadSystem
    public void LoadStats(float savedPlayerHealth, float savedBonusDamage, float savedShield,
        int savedUpgradehealthLevel, int savedUpgradeDamageLevel, int savedUpgradeShieldLevel, bool shipAquired)
    {
        this.playerHealth = savedPlayerHealth;
        this.bonusDamage = savedBonusDamage;
        this.shield = savedShield;

        this.upgradeHealthLevel = savedUpgradehealthLevel;
        this.upgradeDamageLevel = savedUpgradeDamageLevel;
        this.upgradeShieldLevel = savedUpgradeShieldLevel;
        this.shipAquired = shipAquired;
    }

   
}

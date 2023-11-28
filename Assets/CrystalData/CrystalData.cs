using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Money")]
public class CrystalData : ScriptableObject
{
    [SerializeField] int crystals = 0;


    public int GetCrystals()
    {
        return crystals;
    }

    public void SetCrystals(int crystal)
    {
        this.crystals += crystal;
    }

    public void DeleteCrystals(int crystal)
    {
        this.crystals -= crystal;
    }

    public void LoadingSavedCrystals(int savedCrystals)
    {
        this.crystals = savedCrystals;
    }
}

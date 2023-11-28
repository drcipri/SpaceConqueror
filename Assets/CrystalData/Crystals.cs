using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Crystals : MonoBehaviour
{
    [SerializeField] CrystalData crystalData;
    [SerializeField] bool resetCrystals;



    private void Awake()
    { 
        LoadCrystals();    
    }
    private void Update()
    {
        ResetCrystals();
    }


    public void SetUpCrystals(int crystals)
    {

        crystalData.SetCrystals(crystals);
        SaveSystem.SaveCrystals(crystalData);
        
        
    }

    public void GiveCrystals(int crystals)
    {
        crystalData.DeleteCrystals(crystals);
        SaveSystem.SaveCrystals(crystalData);
        
    }


    private void LoadCrystals()
    {
        string path = Application.persistentDataPath + "/Crystals.cotuna";
        if (File.Exists(path))
        {
            GameData gameData = SaveSystem.LoadCrystals();
            crystalData.LoadingSavedCrystals(gameData.GetCrystals());
        }
    }

    private void ResetCrystals()
    {
        if(resetCrystals == true)
        {
            crystalData.LoadingSavedCrystals(0);
            SaveSystem.SaveCrystals(crystalData);
            resetCrystals = false;
        }
    }

  


 

    
}

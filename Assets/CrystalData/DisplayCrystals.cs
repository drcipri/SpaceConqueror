using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayCrystals : MonoBehaviour
{

    [SerializeField] float crystalsIncreaseSpeed = 0.2f;
    [SerializeField] CrystalData crystalData;
     Text displayCrystals;
     int crystals = 0;
     
    // Start is called before the first frame update
    void Start()
    {
        crystals = crystalData.GetCrystals();
        displayCrystals = GetComponent<Text>();
        StartCoroutine(GetCrystalsGradually());
        StartCoroutine(DisplayTheCrystals());
        
    }

   
   


    IEnumerator GetCrystalsGradually()
    {
        
        while (true)
        {
            
            if (crystals < crystalData.GetCrystals())
            {
                if(SceneManager.GetActiveScene().name != "Interface" && crystalData.GetCrystals() - 201 < crystals)
                {
                    crystals++;
                }
                else
                {
                    crystals = crystalData.GetCrystals();
                }
                

            }
            else if(crystals > crystalData.GetCrystals())
            {
                crystals = crystalData.GetCrystals();
            }
            yield return new WaitForSecondsRealtime(crystalsIncreaseSpeed);

        }
    }

    IEnumerator DisplayTheCrystals()
    {
        while(true)
        {
            displayCrystals.text = crystals.ToString();
            yield return new WaitForEndOfFrame();
        }
    }

   
}

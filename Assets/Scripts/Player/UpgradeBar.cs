using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBar : MonoBehaviour
{
    UpgradePlayerGun gunLevel;
    GameObject player;

    int gunLv;
    int checkGunLv = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("ThePlayer");
        gunLevel = player.GetComponent<UpgradePlayerGun>();
        
    }

    // Update is called once per frame
    void Update()
    {
        TurnOn();
    }

    public void TurnOn()
    {
        gunLv = gunLevel.GetUpgradeLevel();
        if (checkGunLv < gunLv)
        {


            if (gunLv == 1)
            {
                
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                checkGunLv++;
            }
            else if (gunLv == 2)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                checkGunLv++;
            }
            else if (gunLv == 3)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                checkGunLv++;
            }
            else if (gunLv == 4)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.GetChild(3).gameObject.SetActive(true);
                checkGunLv++;
            }
            else if (gunLv == 5)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.GetChild(3).gameObject.SetActive(true);
                gameObject.transform.GetChild(4).gameObject.SetActive(true);
                checkGunLv++;
            }
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamLaserManagement : MonoBehaviour
{
    Player player;
    bool setLaserOn = true;
    bool setLaserOff = true;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("ThePlayer").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLaser();
    }

    public void SetLaserOn()
    {
       
        if(setLaserOn == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            setLaserOff = true;
            setLaserOn = true;
        }
    }

    public void SetLaserOff()
    {
        if (setLaserOff == true)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            setLaserOn = false;
            setLaserOff = false;
        }
    }

    public void CheckLaser()
    {
        if(player.GetBeamLaserOnOff() == true)
        {
            SetLaserOn();
        }
        else if (player.GetBeamLaserOnOff() == false)
        {
            SetLaserOff();
        }
    }
}

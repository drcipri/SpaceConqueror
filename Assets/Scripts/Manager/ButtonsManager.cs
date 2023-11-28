using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    GameObject canvas;
    bool playerDeath = false;
    bool winLevel = false;
    float countDownLose = 2f;
    float countDownWin = 1f;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }
    // Update is called once per frame
    void Update()
    {
        LosingWindow();
        WinWindow();
    }

    private void LosingWindow()
    {
        if(playerDeath == true)
        {
            countDownLose -= Time.deltaTime;
            if(countDownLose <= 0)
            {
                Time.timeScale = 0f;
                canvas.transform.GetChild(3).gameObject.SetActive(true);
                playerDeath = false;
                countDownLose = 2f;
            }
        }
    }

    private void WinWindow()
    {
        if(winLevel == true)
        {
           countDownWin -= Time.deltaTime;
            if (countDownWin <= 0)
            {
                Time.timeScale = 0f;
                canvas.transform.GetChild(4).gameObject.SetActive(true);
                winLevel = false;
                countDownWin = 1f;
            }
            
            
        }
    }

    public void SetPlayerDeath(bool playerDeath)
    {
        this.playerDeath = playerDeath;
    }
    public void SetWinLevel(bool winLevel)
    {
        this.winLevel = winLevel;
    }

    public bool GetPlayerDeath()
    {
        return playerDeath;
    }
   


}

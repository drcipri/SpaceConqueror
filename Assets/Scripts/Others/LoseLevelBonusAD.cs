using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseLevelBonusAD : MonoBehaviour
{
    [SerializeField] GameObject confirmWatchingAdWindow;
    [SerializeField] FreePlay freePlay;
    [SerializeField] RestartWave restartWave;
    Button thisButton;
    Image buttonImage;
    float timer = 0.2f;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ButtonProcess);
        
    }

    private void Update()
    {
        ButtonColor();
    }

    public void ButtonProcess()
    {
        
        if (freePlay.GetFreePlay() == true)
        {
            restartWave.RestartWaveForWatchingAds();
        }
        else
        {
            confirmWatchingAdWindow.SetActive(true);
        }
        
    }


    public void ButtonColor()
    {
        timer -= Time.unscaledDeltaTime;
        if (timer < 0f)
        {
            if (buttonImage.color == Color.white)
            {
                buttonImage.color = Color.green;
            }
            else
            {
                buttonImage.color = Color.white;
            }
            timer = 0.2f;
        }



    }


}

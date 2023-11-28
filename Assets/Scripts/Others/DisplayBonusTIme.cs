using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayBonusTIme : MonoBehaviour
{
    [SerializeField] Text displayTime;
    [SerializeField] TimeForBonus time;
    [SerializeField] GameObject watchAdWindow;
    Image buttonImage;
    Button thisButton;
    float timer = 0.2f;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        thisButton = GetComponent<Button>();
        thisButton.interactable = false;
        if(thisButton)
        {
            thisButton.onClick.AddListener(WatchAd);
        }
    }
    private void Update()
    {
        Display();
        
    }

    public void Display()
    {
        if(time.GetAdBonusTime() >= 0.1f )
        {
            displayTime.text = time.GetAdBonusTime().ToString("F1") + "s";
            thisButton.interactable = false;
            buttonImage.color = Color.white;
            
            
        }
        else
        {
            displayTime.text = "BONUS";
            thisButton.interactable = true;
            SetCollor();
            
        }
    }

  

    public void WatchAd()
    {
        watchAdWindow.SetActive(true);
    }

    public void SetCollor()
    {
        
        timer -= Time.deltaTime;
        if(timer < 0f)
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

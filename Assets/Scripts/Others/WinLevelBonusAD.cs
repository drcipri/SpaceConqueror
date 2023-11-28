using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLevelBonusAD : MonoBehaviour
{
    Button thisButton;
    [SerializeField] GameObject confirmWindow;
    float timer = 0.2f;
    Image buttonImage;
    

    // Start is called before the first frame update
    void Start()
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
        confirmWindow.SetActive(true);
        thisButton.interactable = false;
    }

    public void ButtonColor()
    {
        if(thisButton.interactable == true)
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
        else
        {
            buttonImage.color = Color.white;
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmButtons : MonoBehaviour
{

    
    Buttons buttons;
    Button thisButton;

    bool mainMenu = false;
    bool restartLevel = false;
    bool exit = false;

    private void Awake()
    {
        
        buttons = GameObject.FindGameObjectWithTag("ButtonsUtility").GetComponent<Buttons>();
    }
    // Start is called before the first frame update
    void Start()
    {   
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ButtonProcess);
    }

    public void ButtonProcess()
    {
        if(mainMenu == true)
        {
            buttons.MainMenuButton();
            mainMenu = false;
        }
        else if(restartLevel == true)
        {
            buttons.RestartLevel();
            restartLevel = false;
        }
        else if(exit == true)
        {
            buttons.ExitGame();
            exit = false;
        }
    }

    //Set yes or no
    public void MainMenu(bool mainMenu)
    {
        this.mainMenu = mainMenu;    
    }

    public void RestartLevel(bool restartLevel)
    {
        this.restartLevel = restartLevel;
    }

    public void ExitGame(bool exit)
    {
        this.exit = exit;
    }

   




    
}

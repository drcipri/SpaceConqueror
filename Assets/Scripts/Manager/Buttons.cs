using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] LoadSceneAsync loadSceneAsync;
    [SerializeField] GameObject shop;
    GameObject canvas;
    ConfirmButtons confirmButtons;
    Text text;
    [SerializeField]SFX sfx;
    [SerializeField][Range(0,10)] float volume = 10f;
    [SerializeField] GameObject confirmWindow;
    






    private void Start()
    {
        
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        
    }



    //In MainMenuButtons
    
   
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ConfirmSettingsWindow()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        GameObject settingsWindow = GameObject.FindGameObjectWithTag("SettingsWindow");
        settingsWindow.SetActive(false);
    }
    public void OpenSettingsWindow()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        canvas.transform.GetChild(10).gameObject.SetActive(true);
    }

    public void OpenInfoWindow()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        canvas.transform.GetChild(11).gameObject.SetActive(true);

    }

    public void CloseInfoWindow()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        GameObject infoWindow = GameObject.FindGameObjectWithTag("InfoWindow");
        infoWindow.SetActive(false);
    }

    public void OpenHangar()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        canvas.transform.GetChild(12).gameObject.SetActive(true);
    }


    public void CloseHangar()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        GameObject hangarWindow = GameObject.FindGameObjectWithTag("HangarWindow");
        hangarWindow.SetActive(false);
    }

    public void OpenMap()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        loadSceneAsync.LoadSceneInSync("Map");
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void OpenShop()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        shop.SetActive(true);
    }
   




    //For Confirming Buttons
    public void ConfirmMainMenu()
    {
        confirmWindow.SetActive(true);
        confirmButtons = GameObject.FindGameObjectWithTag("Yes").GetComponent<ConfirmButtons>();
        confirmButtons.MainMenu(true);
        text = GameObject.FindGameObjectWithTag("Question").GetComponent<Text>();
        text.text = "Back to main menu ?";
    }
    public void ConfirmRestartLevel()
    {
        confirmWindow.SetActive(true);
        confirmButtons = GameObject.FindGameObjectWithTag("Yes").GetComponent<ConfirmButtons>();
        confirmButtons.RestartLevel(true);
        text = GameObject.FindGameObjectWithTag("Question").GetComponent<Text>();
        text.text = "Restart level ?";
    }

    public void ConfirmExitGame()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        confirmWindow.SetActive(true);
        confirmButtons = GameObject.FindGameObjectWithTag("Yes").GetComponent<ConfirmButtons>();
        confirmButtons.ExitGame(true);
        text = GameObject.FindGameObjectWithTag("Question").GetComponent<Text>();
        text.text = "Exit Game ?";
    }





    //InGame Buttons

    public void MainMenuButton()
    {
        
        Time.timeScale = 1f;
        loadSceneAsync.LoadSceneInSync("Interface");
        AudioListener.pause = false;
    }
    public void RestartLevel()
    {
        
        Time.timeScale = 1f;
        loadSceneAsync.LoadSceneInSync(SceneManager.GetActiveScene().name);
        AudioListener.pause = false;

    }

   
    public void PauseButton()
    {
        AudioListener.pause = true;
        Time.timeScale = 0f;
        canvas.transform.GetChild(5).gameObject.SetActive(true);
        canvas.transform.GetChild(7).gameObject.SetActive(false);
    }

    public void ClosePauseBox()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
        canvas.transform.GetChild(5).gameObject.SetActive(false);
        canvas.transform.GetChild(7).gameObject.SetActive(true);
    }









}

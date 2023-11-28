using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmSpaceShip : MonoBehaviour
{
    [SerializeField] LoadSceneAsync loadSceneAsync;
    [SerializeField]PlayerChoser choser;
    [SerializeField]GameObject player1;
    [SerializeField]GameObject confirmationWindow;
    Button thisButton;
    

    [SerializeField] SFX sfx;
    float volume = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ConfirmPlaySpaceShip);

    }

    


    public void ConfirmPlaySpaceShip()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        confirmationWindow.SetActive(true);
    }

    public void Yes()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        choser.SetPlayerShip(player1);

        loadSceneAsync.LoadSceneInSync("Map");
    }
    public void No()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        confirmationWindow.SetActive(false);  
    }





}

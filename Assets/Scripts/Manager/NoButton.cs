using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoButton : MonoBehaviour
{

    GameObject parent;
    Button button;
    ConfirmButtons confirmButtons;
    
    [SerializeField]SFX sfx;
    [SerializeField][Range(0,10)] float volume = 10f;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
        confirmButtons = parent.transform.GetChild(1).GetComponent<ConfirmButtons>();   
        button = GetComponent<Button>();
        button.onClick.AddListener(CloseWindow);
        
    }

    public void CloseWindow()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        confirmButtons.MainMenu(false);
        confirmButtons.ExitGame(false);
        confirmButtons.RestartLevel(false);
        parent.SetActive(false);
        
    }
}

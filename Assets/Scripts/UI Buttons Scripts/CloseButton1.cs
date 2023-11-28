using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton1 : MonoBehaviour
{
    GameObject shipSettings;
    Button thisButton;
    [SerializeField]SFX sfx;
    [SerializeField] GameObject scrool;
    float volume = 10f;

    
    // Start is called before the first frame update
    void Start()
    {
        shipSettings = gameObject.transform.parent.gameObject;
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(CloseWindow);
    }

    public void CloseWindow()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        shipSettings.SetActive(false);
        StartScrool();
    }

    public void StartScrool()
    {
        ScrollRect scrollRect = scrool.GetComponent<ScrollRect>();
        scrollRect.vertical = true;
    }

    
}

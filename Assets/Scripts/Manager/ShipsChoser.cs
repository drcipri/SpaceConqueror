using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipsChoser : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] GameObject scrool;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject shipSettings;

    //Set Infos
    [Header("Info")]
    [SerializeField] GameObject attackHangar;
    Text attackHangarText;
    [SerializeField] GameObject shieldHangar;
    Text shieldHangarText;
    [SerializeField] GameObject hpHangar;
    Text hpHangarText;
    [SerializeField] GameObject attackSettings;
    Text attackSettingsText;
    [SerializeField] GameObject shieldSettings;
    Text shieldSettingsText;
    [SerializeField] GameObject hpSettings;
    Text hpSettingsText;
    [SerializeField] GameObject shipPrice;
    [SerializeField] GameObject shipimage;

    //others
    Button thisButton;
    

    //Volume
    [Header("Sfx")]
    [SerializeField] SFX sfx;
    float volume = 10f;

    private void Awake()
    {
        
        SetInfoTexts();
        SetPriceAndImage();
        
    }
    private void Start()
    {
        
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(OpenShipSettings);

        
    }
    private void Update()
    {
        WriteShipInfoTexts();
    }

    //Buttons
    public void OpenShipSettings()
    {
        if (shipSettings.activeSelf == false )
        {
            AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
            shipSettings.SetActive(true);
            StopScrool();
        }
    }
    
    
    //TEXTS
    private void WriteShipInfoTexts()
    {
        
        attackHangarText.text = playerStats.GetBonusDamage().ToString() + "%"; 
        shieldHangarText.text = playerStats.GetPlayerShield().ToString();
        hpHangarText.text = playerStats.GetPlayerHealth().ToString();
        attackSettingsText.text = playerStats.GetBonusDamage().ToString() + "%";
        shieldSettingsText.text = playerStats.GetPlayerShield().ToString();
        hpSettingsText.text = playerStats.GetPlayerHealth().ToString();

        
    }

    private void SetInfoTexts()
    {
        attackHangarText = attackHangar.GetComponent<Text>();
        shieldHangarText = shieldHangar.GetComponent<Text>();
        hpHangarText = hpHangar.GetComponent<Text>();
        attackSettingsText = attackSettings.GetComponent<Text>();
        shieldSettingsText = shieldSettings.GetComponent<Text>();
        hpSettingsText = hpSettings.GetComponent<Text>();
    }


    public void StopScrool()
    {
        ScrollRect scrollRect = scrool.GetComponent<ScrollRect>();
        scrollRect.vertical = false;
    }

    public void SetPriceAndImage()
    {
        if(playerStats.GetIfShipIsBought() == false)
        {
            shipPrice.SetActive(true);
            shipimage.GetComponent<Image>().color = Color.grey;
        }
    }


    

}

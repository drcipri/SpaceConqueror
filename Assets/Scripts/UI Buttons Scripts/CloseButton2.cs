using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton2 : MonoBehaviour
{
    [SerializeField]GameObject window;
    [SerializeField] SFX sfx;
    float volume = 10f;
    [SerializeField]Button winLevelAdsButton;

    public void CloseWindow()
    {
        AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
        window.SetActive(false);
        if(winLevelAdsButton != null)
        {
            winLevelAdsButton.interactable = true;
        }
    }

}

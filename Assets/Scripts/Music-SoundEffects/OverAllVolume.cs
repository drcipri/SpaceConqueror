using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverAllVolume : MonoBehaviour
{
    
    [SerializeField]Slider slider;



    private void Start()
    {
        slider.value = AudioListener.volume;
        
    }
    // Update is called once per frame
    void Update()
    {
        SaveVolume();
            
    }

    public void SaveVolume()
    {
        AudioListener.volume = slider.value;
        if (slider.value != PlayerPrefs.GetFloat("GeneralVolume"))
        {
            PlayerPrefs.SetFloat("GeneralVolume", slider.value);
        }

    }

    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    [SerializeField] Slider slider;
    AudioSource musicPlayer;


    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>();
        slider.value = musicPlayer.volume;
    }

    // Update is called once per frame
    void Update()
    {
        SaveMusicVolume();
    }

   

    public void SaveMusicVolume()
    {
        musicPlayer.volume = slider.value;
        if (slider.value != PlayerPrefs.GetFloat("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", slider.value);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [Header("Background Music")]
    [SerializeField] SFX backgroundMusic;
    [SerializeField] int track = 0;
    AudioSource musicPlayer;
    bool playMusic = true;
    Player player;
    

    

    private void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        SetMusicVolume();
        SetAudioListner();
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        if (player != null)
        {
            if (playMusic == true && player.GetMovingPlayerAtStart() == false)
            {
                
                musicPlayer.clip = backgroundMusic.GetBackgroundMusic(track);
                musicPlayer.Play();
                playMusic = false;

            }
        }
        else if (SceneManager.GetActiveScene().name == "Interface" && playMusic == true)
        {
            
            track = 3;
            musicPlayer.clip = backgroundMusic.GetBackgroundMusic(track);
            musicPlayer.Play();
            playMusic = false;
        }
        else if (SceneManager.GetActiveScene().name == "Map" && playMusic == true)
        {
            track = 4;
            musicPlayer.clip = backgroundMusic.GetBackgroundMusic(track);
            musicPlayer.Play();
            playMusic = false;
        }
        
    }

    public void SetTrackMusic(int track)
    {
        this.track = track;
        playMusic = true;
    }

    public void SetAudioListner()
    {
        if(PlayerPrefs.HasKey("GeneralVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("GeneralVolume");

        }
        else
        {
            PlayerPrefs.SetFloat("GeneralVolume", AudioListener.volume);
        }
    }

    public void SetMusicVolume()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicPlayer.volume = PlayerPrefs.GetFloat("MusicVolume");
            

        }
        else
        {
            PlayerPrefs.SetFloat("MusicVolume", musicPlayer.volume);
        }
    }
}

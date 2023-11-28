using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FreePlayLoader : MonoBehaviour
{
    [SerializeField] FreePlay freePlay;

    private void Awake()
    {
        SingleTon();
        LoadFreePlay();
        
    }

    private void LoadFreePlay()
    {
        string path = Application.persistentDataPath + "/FreePlay.cotuna";
        if (File.Exists(path))
        {
            GameData gameData = SaveSystem.LoadFreePlay();
            freePlay.LoadFreePlay(gameData.GetFreePlayGameData());
        }
    }
    public void SingleTon()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

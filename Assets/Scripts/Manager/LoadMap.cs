using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadMap : MonoBehaviour
{
    [SerializeField] ManageScene manageScene;

    private void Awake()
    {
        LoadScenesFiles();
    }
    private void LoadScenesFiles()
    {
        string path = Application.persistentDataPath + "/Scenes.cotuna";
        if (File.Exists(path))
        {
            GameData gameData = SaveSystem.LoadScenes();
            manageScene.LoadScenes(gameData.GetLevelsClearedGameData());
        }
    }
}

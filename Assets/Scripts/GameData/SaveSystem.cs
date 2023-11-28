using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem 
{
   //saving crystals
    public static void SaveCrystals(CrystalData crystalData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Crystals.cotuna";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(crystalData);
        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData LoadCrystals()
    {
        string path = Application.persistentDataPath + "/Crystals.cotuna";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }


    //Saving Upgrades
    public static void SaveUpgrades(PlayerStats playerStats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + playerStats.name + ".cotuna";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(playerStats);
        formatter.Serialize(stream, gameData);
        stream.Close();
    }
    public static GameData LoadPlayerStats(PlayerStats playerStats)
    {
        string path = Application.persistentDataPath + "/" + playerStats.name + ".cotuna";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }

    //Saving scenes
    public static void SaveScenes(ManageScene manageScene)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Scenes.cotuna";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(manageScene);
        formatter.Serialize(stream, gameData);
        stream.Close();
    }
    public static GameData LoadScenes()
    {
        string path = Application.persistentDataPath + "/Scenes.cotuna";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }

    //saving freePlay
    public static void SaveFreePlay(FreePlay freePlay)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/FreePlay.cotuna";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(freePlay);
        formatter.Serialize(stream, gameData);
        stream.Close();
    }
    public static GameData LoadFreePlay()
    {
        string path = Application.persistentDataPath + "/FreePlay.cotuna";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }


}

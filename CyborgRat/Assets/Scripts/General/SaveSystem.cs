using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    static string saveFileName = "_savefile.sav";

    public static void SaveGame(GameData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = FilePath(data.playerName);
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame(string playerName)
    {
        string path = FilePath(playerName);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }

        return null;
    }

    public static string[] ReadAllSaveGames()
    {
        string[] filesInfo = Directory.GetFiles(Application.persistentDataPath);
        List<string> playerNames = new List<string>();

        foreach (string file in filesInfo)
        {
            playerNames.Add(file.Replace(Application.persistentDataPath, "").Replace(saveFileName, "").Replace(Path.DirectorySeparatorChar.ToString(), ""));
        }

        return playerNames.ToArray();
    }

    static string FilePath(string playerName)
    {
        return Application.persistentDataPath + Path.DirectorySeparatorChar + playerName + saveFileName;
    }
}

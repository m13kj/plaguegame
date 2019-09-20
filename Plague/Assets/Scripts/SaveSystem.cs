using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void Save(PlayerController player, int saveSlot)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string          path      = Application.persistentDataPath + "/save" + saveSlot.ToString();
        FileStream      stream    = new FileStream(path, FileMode.Create);
        SaveData        data      = new SaveData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData Load(int saveSlot)
    {
        string path = Application.persistentDataPath + "/save" + saveSlot.ToString();
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream      stream    = new FileStream(path, FileMode.Open);
            SaveData        data      = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        return null;
    }
}

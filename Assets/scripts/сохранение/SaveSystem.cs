using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveSystem 
{
    public static void SetPlayer(GameManage player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";//persistentDataPath сохраняет путь в любой операционной системе
        FileStream stream = new FileStream(path, FileMode.Create);//создается файл

        PlayerData data = new PlayerData(player);//данные об игроке

        formatter.Serialize(stream, data);//записываются данные
        stream.Close();//закрывается поток
    }

    public static PlayerData LoadPlayer()//чтение данных из файла
    {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))//если файл существует, то начать чтение и "вывести" данные в игру
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else//иначе ошибка
        {
            Debug.LogError("save file not found in "+path);
            return null;
        }
    }
}

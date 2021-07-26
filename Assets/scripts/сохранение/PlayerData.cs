using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]//это сериализация для того чтобы значения можно было сохранить в файле

public class PlayerData 
{
    public float points;//очки
    public float[] doodlePositions;//массив для сохранения местоположения дудлика

    public PlayerData(GameManage player)
    {
        points = player.points;//передаем значение points из gameManage.cs

        doodlePositions=new float[3];
        doodlePositions[0] = player.transform.position.x;
        doodlePositions[1] = player.transform.position.y;
        doodlePositions[2] = player.transform.position.z;
    }
}

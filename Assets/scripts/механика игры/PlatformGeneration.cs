using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject platformPrefers;
    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();//новая позиция платформ

        for (int i=0;i<10;i++) //создаются 10 платформ
        {
            SpawnerPosition.x = Random.Range(-4.7f, 4.7f); //рандомная позиция по у
            SpawnerPosition.y += Random.Range(2f,3f);//платформы по у становятся чуть выше предыдущей платформы

            Instantiate(platformPrefers, SpawnerPosition, Quaternion.identity); //платформы перемещаются наверх как только выходят за пределы камеры
        }
    }
}

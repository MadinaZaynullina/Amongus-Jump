using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public void SetPlayer(int index)//для смены скина
    {
        PlayerPrefs.SetInt("player", index);//устанавливает значения ключа сохранения типа int (ключ сохранения = player)
    }
    public void FixedUpdate()
    {

        if (PlayerPrefs.GetInt("player") == 0)
        {
            text1.SetActive(true);
        }
        else
        {
            text1.SetActive(false);
        }
        if (PlayerPrefs.GetInt("player") == 1)
        {
            text2.SetActive(true);
        }
        else
        {
            text2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("player") == 2)
        {
            text3.SetActive(true);
        }
        else
        {
            text3.SetActive(false);
        }
        if (PlayerPrefs.GetInt("player") == 3)
        {
            text4.SetActive(true);
        }
        else
        {
            text4.SetActive(false);
        }
    }
}

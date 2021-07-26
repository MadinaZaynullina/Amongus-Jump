using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathNotification : MonoBehaviour
{
    public GameObject deadAnnouncement;
    public void Update()
    {
        if (Doodle.instance.isDead==true)
        {
            deadAnnouncement.SetActive(true);//если персонаж мертв,  то включается меню смерти
            Time.timeScale = 0f;
        }
    }
    public void Resume()//продолжить
    {
        Time.timeScale = 1f;
        Doodle.instance.isDead = false;//это не обязательно, но я решила на всякий случай оставить
        deadAnnouncement.SetActive(false);//меню не отображается
        SceneManager.LoadScene(1);//перезагрузка уровня
        
    }
    public void LoadMenu()
    {
        {
            Doodle.instance.isDead = false;
            SceneManager.LoadScene(0);//загражается сцена с главным меню
            Time.timeScale = 1f;
        }
    }
}

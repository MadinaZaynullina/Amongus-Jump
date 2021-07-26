using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;//игра стоит на паузе или нет 
    public GameObject PauseGameMenu;//менюшка, выпадающая на паузе

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//если нажали на esc
        {
            if (PauseGame) //если true
            {
                Resume();//то игра продолжается
            }
            else
            {
                Pause();//иначе стоит на паузе
            }
        }
    }
    public void Resume()//продолжить
    {
        PauseGameMenu.SetActive(false);//меню не отображается
        Time.timeScale = 1f;//игра продолжается
        PauseGame = false;//для esc
    }
    public void Pause()//пауза
    {
        PauseGameMenu.SetActive(true);//меню отображается
        Time.timeScale = 0f;//время остановилось
    }
    public void LoadMenu()//выход на главное меню
    {
        Time.timeScale = 1f;//время идет как обычно(сделано для того, чтобы при повторном входе игры она не сояла на паузе)
        SceneManager.LoadScene(0);//загражается сцена с главным меню
    }

}

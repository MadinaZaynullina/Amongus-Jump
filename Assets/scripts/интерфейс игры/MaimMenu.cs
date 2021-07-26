using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaimMenu : MonoBehaviour
{
    public void PlayGame()//метод для перехода к игре
    {
        SceneManager.LoadScene(1);//загружается следующая сцена (сделано таким образом,так как названия сцен могут меняться)
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Игра завершилась");//сообщение о завершении игры при закрытии
        Application.Quit();//выход
    }
}

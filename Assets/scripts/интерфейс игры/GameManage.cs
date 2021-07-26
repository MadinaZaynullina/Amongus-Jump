using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject PauseMenu;
    public Text pointsText1;//текст с выводом очков
    public Text pointsText2;//текст с выводом очков
    public float points = 0;//сами очки
    
    private Doodle player;//дудлик (значение используется)
    public Transform doodlePos;//позиция, на которой спавнится дудлик
    public GameObject[] players;//массив для хранения игроков
    public static GameManage instance = null;

    float timeExpaning = 0.1f;//на сколько увеличивается игра с набором 1000 очков
    int border=1000;//когда начинается ускорение
    bool isNewGame = true;//это новая игра, то есть она не начата после смерти или загрузки сохраненного прогресса (нужно для корректного ускорения игры)

    public void Start()
    {
       
    }
    public void Awake()
    {
        player = Instantiate(players[PlayerPrefs.GetInt("player")], doodlePos.position, Quaternion.identity).GetComponent<Doodle>();
        //instansiate создает какой-то объект(в данном случае персонажей с разными скинами), Quaternion.identity-ориентация
    }

    void Update()
    {
        string textPoints = points.ToString();
        pointsText1.text = textPoints;//вывод очков на экран
        pointsText2.text = textPoints;//вывод очков на экран
        if (isNewGame==false||Doodle.instance.isDead==false)
        {
            if (points > border)//если кол-во очков больше некой границы, то
            {
                border += 1000;//смещение границ
                Time.timeScale = timeExpaning + 1f;//увеличение скорости игры
                timeExpaning += 0.1f;
            }
        }
        else
        {
            timeExpaning = 1f;
            border = 1000;
            isNewGame = false;
        }

    }
    public void FixedUpdate()
    {
        if (Doodle.instance.isDead == false)//если персонаж еще не умер, то прибавляется очки
        {
            points++;//каждое фиксированное кол-во времени прибавляется по одному очку
        }
    }

    public void SavePlayer()//сохранение
    {
        SaveSystem.SetPlayer(this);
    }
    public void LoadPlayer()
    {
        PauseMenu.SetActive(false);//меню паузы убирается
        PlayerData data = SaveSystem.LoadPlayer();//загрузка игрокa
        isNewGame = false;//не новая игра
        try
        {
            points = data.points;//загрузка очков

            Vector3 position;
            position.x = data.doodlePositions[0];//данные из PlayerData.css
            position.y = data.doodlePositions[1];
            position.z = data.doodlePositions[2];
            transform.position = position;//дудлик отображается на прошлом местоположении
            isNewGame = false;//не новая игра
            Time.timeScale = 1f;//при загрузке время идет
        }
        catch
        {

            throw new System.Exception("there are no saved games");
        }
    }

}

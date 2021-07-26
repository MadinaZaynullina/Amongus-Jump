using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //для перезапуска сцены

public class Doodle : MonoBehaviour
{
    public static Doodle instance=null;//переменная с помощью которой мы может в platform.cs получить доступ к DoodleRigid
    public Rigidbody2D DoodlerRigid;//физическое воплощение дудлика
    public float speed;//скорость с который дудлик перемеается вправо и влево
    public bool isDead = false;//умер ли дулик (передается в gameManage.cs)

    bool isRigth=true;//необходимо для вращения

    void Start()
    {
        if (instance==null)
        {
            instance = this;//для передачи данных в platform.cs
        }
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);//если наживают на клавишу A или влево, то дудлик движется влево (умножаем на Time.deltaTime для того чтобы перемещание было не в м/кадр, м/c)
            if (!isRigth)//если дудлику нужно повернуться влево, то он делает это единожды
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);//поворот по оси х (т.е. в противоположную сторону)
                isRigth = !isRigth;
            }
        }   
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if(isRigth)//если дудлику нужно повернуться вправо, то он делает это единожды
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);//поворот по оси х (т.е. в противоположную сторону)
                isRigth = !isRigth;
            }
        }

    }
public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name=="DeadZone") //если касается DeadZone 
        {
            isDead = true;//фиксируется смерть
            Time.timeScale = 1f;
        }
    }

}

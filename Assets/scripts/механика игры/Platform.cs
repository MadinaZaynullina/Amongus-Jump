using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float forceJump;//сила прыжка
    
    public void OnCollisionEnter2D(Collision2D collision)
    { //прыжок от платформы
        if (collision.relativeVelocity.y < 0)//если дудлик летит вниз
        {
            Doodle.instance.DoodlerRigid.velocity = Vector2.up * forceJump;//прыгает
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name=="DeadZone")//если платформа касается дедзон, то создаются рандомные числа типа float по у и х
        {
            float RandX = Random.Range(-4.7f, 4.7f);
            float RandY = Random.Range(transform.position.y + 20f, transform.position.y + 20.5f);

            transform.position = new Vector3(RandX, RandY, 0);//в итоге позиция платформы это новый вектор
        }
    }
}

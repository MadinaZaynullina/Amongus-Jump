using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform doodlePos;
    public void Start()
    {
        doodlePos = GameObject.FindGameObjectWithTag("doodle").transform;
        transform.position = new Vector3(-0.3861731f, 3.08182f, -10);
    }
    void Update()
    {
        if (doodlePos.position.y>transform.position.y)//если дудлик прыгает
        {
            transform.position = new Vector3(transform.position.x, doodlePos.position.y, transform.position.z);//камера следует за дудликом по оси у
        }
    }
}

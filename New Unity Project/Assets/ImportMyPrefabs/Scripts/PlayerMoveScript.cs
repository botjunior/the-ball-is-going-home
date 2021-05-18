using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float speed;
    Rigidbody _rd;
    private void Start()
    {
        _rd = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {

        MovementLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");//получаем движение в случае нажатия клавиши w s

        float moveVertical = Input.GetAxis("Vertical");//получаем движение в случае нажатия клавиши a d

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);// создаём новый вектор, в сторону которого мы будем двигаться

        _rd.AddForce(movement * speed);// направляем текущий Rigidbody по вектору * на скорость 
    }
}

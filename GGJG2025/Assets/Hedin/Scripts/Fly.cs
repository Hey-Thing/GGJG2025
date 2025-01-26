using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private bool Up;
    private bool Down;

    void Start()
    {
        Up = true;
        Down = false;
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);


        float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        if (transform.position.y >= screenTop)
        {
            Up = true;
            Down = false;
        }
        if (transform.position.y <= screenBottom)
        {
            Down = true;
            Up = false;
        }

        if (Up)
        {
            goingUp();
        }
        if (Down)
        {
            goingDown();
        }
    }
    void goingUp()
    {
        transform.Translate(Vector2.down * Time.deltaTime);
    }
    void goingDown()
    {
        transform.Translate(Vector2.up * Time.deltaTime);
    }
}

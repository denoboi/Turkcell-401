using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    float speed;
    float acceleration;
    float maxSpeed;

    bool movement;

    // Start is called before the first frame update
    void Start()
    {
        if(movement)
        {
            CameraMove();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }

    void CameraMove()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        speed += acceleration * Time.deltaTime; 
        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    float speed;
    float acceleration;
    float maxSpeed;

    bool movement = true;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        acceleration = 0.2f;
        maxSpeed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement)
        {
            CameraMove();
        }
        
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

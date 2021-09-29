using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    float backGroundPos;
    float distance = 10.24f;
    // Start is called before the first frame update
    void Start()
    {
        backGroundPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(backGroundPos + distance < Camera.main.transform.position.y)
        {
            BackgroundPlacement();
        }
    }

    void BackgroundPlacement()
    {
        backGroundPos += (distance * 2);
        Vector2 newPosition = new Vector2(0, backGroundPos);
        transform.position = newPosition;
    } 
}

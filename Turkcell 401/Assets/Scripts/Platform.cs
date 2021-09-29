using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;

    float randomSpeed;

    bool movement = true;

    /// <summary>
    /// yani bu property eger bir boolean deger ile cagrilirsa ona hareket degiskenini
    ///  atiyoruz. Cunku bu degiskene direkt erisim vermiyoruz.
    public bool Movement
    {
        get { return movement; }
        set { movement = value; }  
    } 
    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        randomSpeed = Random.Range(0.5f, 1f);
    }

    void Update()
    {
        if(movement)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed, 3f);
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }
}

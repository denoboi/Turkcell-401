using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;

    float randomSpeed;

    bool movement = true;

    float min, max;

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

        float objectWidth = polygonCollider2D.bounds.size.x / 2;

        if (transform.position.x > 0) // yani ekranin sagindaysa
        {
            //ekranin saginin baslangic noktasi bu. colliderin yarisini kesiyoruz ki tasmasin
            min = objectWidth;
            max = ScreenCalculator.instance.Width - objectWidth;
        }
        else //ekranin sol tarafi icin
        {
            min = -ScreenCalculator.instance.Width + objectWidth;
            max = -objectWidth;
        }
    }

    void Update()
    {
        if(movement)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }
}

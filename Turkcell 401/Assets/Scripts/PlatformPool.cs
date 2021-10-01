using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab = default;
    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPos;

    [SerializeField]
    float platformDistance = 40.0f;

    void Start()
    {
        PlatformSpawn();
    }

    // Update is called once per frame


    void PlatformSpawn()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPos, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Movement = true;
            platform.transform.position = platformPos;
            NextPlatformPos();
        }
    }

    void LocatePlatform()
    {

    }

    /// <summary>
    /// Bu metod her cagrildiginda yukarida olusturdugumuz metodun pozisyonunu degistirecek
    /// Yapmak istedigimiz sey bir ustteki platformun ustunde ve random uretmek
    /// </summary>
    void NextPlatformPos()
    {
        float random = Random.Range(0f, 1f);
        platformPos.y += platformDistance;
        if (random < 0.5f)
        {
            platformPos.x = ScreenCalculator.instance.Width / 2;
        }else
        {
            platformPos.x = -ScreenCalculator.instance.Width / 2;
        }
           
    }
}

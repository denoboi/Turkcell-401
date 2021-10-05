 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab = default;
    List<GameObject> platforms = new List<GameObject>();

    [SerializeField]
    GameObject deadlyPlatformPrefab;

    [SerializeField]
    GameObject playerPrefab = default;

    Vector2 platformPos;
    Vector2 playerPos;

    [SerializeField]
    float platformDistance = 40.0f;


    void Start()
    {
        PlatformProduce();
    }

    // Update is called once per frame
    private void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y < Camera.main.transform.position.y + ScreenCalculator.instance.Height)
        {
            LocatePlatform();
        }
    }


    void PlatformProduce()
    {
        platformPos = new Vector2(0, 0);
        playerPos = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPos, Quaternion.identity);
        GameObject firstPlatform = Instantiate(platformPrefab, platformPos, Quaternion.identity);

        platforms.Add(firstPlatform);
        NextPlatformPos();
        firstPlatform.GetComponent<Platform>().Movement = false;

        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPos, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Movement = true;
            platform.transform.position = platformPos;
            NextPlatformPos();
        }
        GameObject deadlyPlatform = Instantiate(deadlyPlatformPrefab, platformPos, Quaternion.identity);
        platforms.Add(deadlyPlatform);
        NextPlatformPos();
    
    }


    void LocatePlatform()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            //en bastaki 5 tanenin yerini degistirince i+5'te bulunan platformlar en basa gidiyor bunlara dokunmuyoruz
            temp = platforms[i + 5];
            //burada en bastaki platformu 5 birim oteliyoruz
            platforms[i + 5] = platforms[i];
            //tempe aldigimiz objeyi de en basa yerlestiriyoruz
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPos;
            NextPlatformPos();
        }
    }

    /// <summary>
    /// Bu metod her cagrildiginda yukarida olusturdugumuz metodun pozisyonunu degistirecek
    /// Yapmak istedigimiz sey bir ustteki platformun ustunde ve random uretmek
    /// </summary>
    void NextPlatformPos()
    {
        platformPos.y += platformDistance;
        float random = Random.Range(0f, 1f);
        
        if (random < 0.5f)
        {
            platformPos.x = ScreenCalculator.instance.Width / 2;
        }else
        {
            platformPos.x = -ScreenCalculator.instance.Width / 2;
        }
           
    }
}

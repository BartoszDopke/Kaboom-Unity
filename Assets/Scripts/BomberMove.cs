using UnityEngine;
using UnityEngine.SceneManagement;

public class BomberMove : MonoBehaviour
{
    public float speed;
    public float start_speed;
    public Rigidbody2D rb;
    public GameObject apple;
    public GameObject bonus, bonusdeath;
    public GameObject bomber;
    Vector3 NextPoint;
    public float nMin;
    public float nMax;
    public float bMin = -8.5f;
    public float bMax = 8.5f;
    float RandomChoiceBonus;
    float defaultWidth;

    //tworzy nowy losowy punkt, do którego dochodzi Bomber
    Vector3 GenerateNextPoint(float min, float max)
    {
        return (new Vector3(Random.Range(min, max), transform.position.y,0));
    }
    float GenerateRandomChoice(float min, float max)
    {
        return Random.Range(min, max);
    }

    //spawnuje bomby
    void Spawn()
    {
        GameObject newapple = (GameObject)Instantiate(apple) as GameObject;
        if (newapple != null)
        {
            float x = bomber.transform.position.x;
            float y = bomber.transform.position.y - 1.0f;
            newapple.transform.position = new Vector2(x, y);
        }
    }

    void SpawnBonus()
    {
        float ybonus = 2.5f;
        if (RandomChoiceBonus < 0.4f)
        {
            GameObject newbonus = (GameObject)Instantiate(bonus) as GameObject;
            newbonus.transform.position = new Vector2(RandomChoiceBonus, ybonus);
        }
        else
        {
            GameObject newbonusdeath = (GameObject)Instantiate(bonusdeath) as GameObject;
            newbonusdeath.transform.position = new Vector2(RandomChoiceBonus, ybonus);
        }
    }

    //metody zmieniające prędkość Bombera oraz częstotliwość zrzutu bomb w zależności od trybu gry
    public void SpawnDelayOnePlayer()
    {
        InvokeRepeating("Spawn", 0.5f, 0.5f);
        InvokeRepeating("SpawnBonus", 2f, 8f);
    }
    public void SpawnDelayTwoPlayers()
    {
        InvokeRepeating("Spawn", 0.5f, 0.4f);
        InvokeRepeating("SpawnBonus", 2f, 8f);
    }

    public void Speed_Increase()
    {
        if(Score.points % 100 == 0)
        {  
           speed = start_speed + Score.points/100 * 0.1f;
        }   
    }
    //wywołuje spawn co określony czas
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "OnePlayer")
        {
            SpawnDelayOnePlayer();
        }
        else if(sceneName == "TwoPlayers")
        {
            SpawnDelayTwoPlayers();
        }
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
        nMin = 0 - defaultWidth;
        nMax = 0 + defaultWidth;
        NextPoint = GenerateNextPoint(nMin, nMax);
    }

    void Update()
    {
        //if(maintainWidth)
        //{
        //    Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;
        //}

       if (Vector3.Distance(transform.position, NextPoint) > 0.5f && Time.timeScale != 0) //vector3.distance zwraca mi dystans między a i b
       {
            transform.position = Vector3.Lerp(transform.position, NextPoint, 0.02f * speed); //dzięki speed/int zmieniam prędkość zmian pozycji Bombera
        }
       else
       {
            NextPoint = GenerateNextPoint(nMin, nMax);
       }
       Speed_Increase();
       RandomChoiceBonus = GenerateRandomChoice(bMin, bMax);
    }
}


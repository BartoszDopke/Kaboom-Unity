using UnityEngine;
using UnityEngine.SceneManagement;

public class BomberMoveVs : MonoBehaviour
{
    private float speed = 0.5f;
    public float start_speed = 0.5f;
    public Rigidbody2D rb;
    public GameObject apple;
    public GameObject apple2;
    public GameObject bomber;
    Vector3 NextPoint;
    float RandomChoice;
    public float nMin = -8f;
    public float nMax = 8f;
    public float cMin = 0f;
    public float cMax = 1f;
    public float yStart = 3.37f;
    

    //tworzy nowy losowy punkt, do którego dochodzi Bomber
    Vector3 GenerateNextPoint(float min, float max)
    {
        return (new Vector3(Random.Range(min, max), 3.37f, yStart));
    }
    //losowy punkt dla bomb
    float GenerateRandomChoice(float min,float max)
    {
        return Random.Range(min, max);
    }

    //spawnuje bomby
    void Spawn()
    { 
        
        GameObject newapple2 = (GameObject)Instantiate(apple2) as GameObject;
        GameObject newapple = (GameObject)Instantiate(apple) as GameObject;
        if (newapple != null || newapple2!= null)
        {
            float x = bomber.transform.position.x;
            float y = bomber.transform.position.y - 1.0f;
            if(RandomChoice < 0.4f)
                newapple.transform.position = new Vector2(x, y);
            else
            {
                newapple2.transform.position = new Vector2(x, y);
            }
        }
    }

    //metody zmieniające prędkość Bombera oraz częstotliwość zrzutu bomb w zależności od trybu gry
    public void SpawnDelayOnePlayer()
    {
        speed = 0.4f;
        InvokeRepeating("Spawn", 0.5f, 0.4f);
    }
    public void SpawnDelayTwoPlayers()
    {
        speed = 0.9f;
        InvokeRepeating("Spawn", 0.5f, 0.2f);
    }
    public void SpawnDelayTwoPlayersVs()
    {
        speed = 0.9f;
        InvokeRepeating("Spawn", 0.5f, 0.5f);
    }
    public void Speed_Increase()
    {
        if (Score.points % 100 == 0)
        {
            speed = start_speed + ScoreVS.points / 100 * 0.1f;
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
        else if (sceneName == "TwoPlayers")
        {
            SpawnDelayTwoPlayers();
        }
        else if (sceneName == "TwoPlayersVs")
        {
            SpawnDelayTwoPlayersVs();
            Debug.Log("Wejście do TwoPlayersVs");
        }
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        NextPoint = GenerateNextPoint(nMin, nMax);
        RandomChoice = GenerateRandomChoice(cMin, cMax); 

    }


    void Update()
    {

        if (Vector3.Distance(transform.position, NextPoint) > 0.5f) //vector3.distance zwraca mi dystans między a i b
        {
            transform.position = Vector3.Lerp(transform.position, NextPoint, speed / 20); //dzięki speed/int zmieniam prędkość zmian pozycji Bombera
        }
        else
        {
            NextPoint = GenerateNextPoint(nMin, nMax);
            RandomChoice = GenerateRandomChoice(cMin, cMax);
        }
        Speed_Increase();

    }

}

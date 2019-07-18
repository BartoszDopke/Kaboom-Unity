using UnityEngine;
using UnityEngine.SceneManagement;

public class BomberMoveVs : MonoBehaviour
{
    public float speed = 0.5f;
    public float start_speed = 0.5f;
    public Rigidbody2D rb;
    public GameObject apple;
    public GameObject apple2;
    public GameObject bonus;
    public GameObject bomber;
    Vector3 NextPoint;
    float RandomChoice;
    float RandomChoiceBonus;
    public float nMin = -8.8f;
    public float nMax = 8.8f;
    public float cMin = 0f;
    public float cMax = 1f;
    public float yStart = 3.37f;
    public float bMin = -8.5f;
    public float bMax = 8.5f;
    public float spawn = 0.5f;
    private float newspawn = 0.5f;


    //tworzy nowy losowy punkt, do którego dochodzi Bomber
    Vector3 GenerateNextPoint(float min, float max)
    {
        return (new Vector3(Random.Range(min, max), yStart, 0));
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

    void SpawnBonus()
    {
        GameObject newbonus = (GameObject)Instantiate(bonus) as GameObject;
        if(newbonus!=null)
        { 
            float y = 2.5f;
           //Debug.Log("RandomChoiceBonus: " + RandomChoiceBonus);
            newbonus.transform.position = new Vector2(RandomChoiceBonus, y); //do poprawki
            //Debug.Log("blue bomb position: " + newbonus.transform.position);
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
        InvokeRepeating("Spawn", 0.5f, newspawn);
        InvokeRepeating("SpawnBonus", 2f, 5f);
    }
    //ta funkcja działa bez zarzutu
    public void Speed_Increase()
    {
        if (ScoreVS.points % 100 == 0)
        {
            speed = start_speed + ScoreVS.points / 100 * 0.05f;
            //Debug.Log("speed: " + speed);
        }

    }

    public void Spawn_Increase()
    {
        if(ScoreVS.points % 100 == 0)
        {
            newspawn = spawn - ScoreVS.points / 100 * 0.05f;            
        }
        if(newspawn <= 0)
        {
            newspawn = 0;
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
        }
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        NextPoint = GenerateNextPoint(nMin, nMax);
        RandomChoice = GenerateRandomChoice(cMin, cMax);
        speed = 0.5f;
        newspawn = 0.5f;

    }


    void Update()
    {

        if (Vector3.Distance(transform.position, NextPoint) > 0.5f && Vector3.Distance(transform.position, NextPoint) < 11f) //vector3.distance zwraca mi dystans między a i b
        {
            transform.position = Vector3.Lerp(transform.position*Time.timeScale, NextPoint, speed / 20); //dzięki speed/int zmieniam prędkość zmian pozycji Bombera
        }
        else
        {
            NextPoint = GenerateNextPoint(nMin, nMax);
            

        }
        Speed_Increase();
        Spawn_Increase();
        RandomChoice = GenerateRandomChoice(cMin, cMax);
        RandomChoiceBonus = GenerateRandomChoice(bMin, bMax);
        //Debug.Log("Spawn in Update: " + newspawn);

    }

}

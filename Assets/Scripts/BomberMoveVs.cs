using UnityEngine;
using UnityEngine.SceneManagement;

public class BomberMoveVs : MonoBehaviour
{
    public float speed;
    public float start_speed;
    public Rigidbody2D rb;
    public GameObject apple;
    public GameObject apple2;
    public GameObject bonus, bonusdeath;
    public GameObject bomber;
    Vector3 NextPoint;
    float RandomChoice;
    float RandomChoiceBonus;
    public float cMin = 0f;
    public float cMax = 1f;
    public float yStart = 3.37f;
    public float bMin = -8.5f;
    public float bMax = 8.5f;
    public float nMin;
    public float nMax;
    private float spawn = 0.3f;
    private float newspawn = 0.3f;
    float defaultWidth;


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
        float x = bomber.transform.position.x;
        float y = bomber.transform.position.y - 1.0f;
            if(RandomChoice < 0.5f)
            {
                GameObject newapple = (GameObject)Instantiate(apple) as GameObject;
                newapple.transform.position = new Vector2(x, y);
            }
            else
            {
                GameObject newapple2 = (GameObject)Instantiate(apple2) as GameObject;
                newapple2.transform.position = new Vector2(x, y);
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
    public void SpawnDelayTwoPlayersVs()
    {
        speed = 0.9f;
        InvokeRepeating("Spawn", 0.5f, newspawn);
        InvokeRepeating("SpawnBonus", 2f, 7f);
    }
    //ta funkcja działa bez zarzutu
    public void Speed_Increase()
    {
        if (ScoreVS.points % 100 == 0)
        {
            speed = start_speed + ScoreVS.points / 100 * 0.05f;
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
        SpawnDelayTwoPlayersVs();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        RandomChoice = GenerateRandomChoice(cMin, cMax); 
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
        nMin = 0 - defaultWidth;
        nMax = 0 + defaultWidth;
        NextPoint = GenerateNextPoint(nMin, nMax);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, NextPoint) > 0.5f && Time.timeScale != 0) //vector3.distance zwraca mi dystans między a i b
        {
            transform.position = Vector3.Lerp(transform.position, NextPoint, 0.02f * speed); //dzięki speed/int zmieniam prędkość zmian pozycji Bombera
        }
        else
        {
            NextPoint = GenerateNextPoint(nMin, nMax);
        }
        Speed_Increase();
        Spawn_Increase();
        RandomChoice = GenerateRandomChoice(cMin, cMax);
        RandomChoiceBonus = GenerateRandomChoice(bMin, bMax);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class BomberMoveVs : MonoBehaviour
{
    private float speed = 0.5f;
    private float start_speed = 0.5f;
    public Rigidbody2D rb;
    public GameObject apple;
    public GameObject apple2;
    public GameObject bonus, bonusdeath;
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
    private float spawn = 0.3f;
    private float newspawn = 0.3f;


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
            if(RandomChoice < 0.4f)
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
                //Debug.Log("blue bomb position: " + newbonus.transform.position);
            }
            else
            {
                GameObject newbonusdeath = (GameObject)Instantiate(bonusdeath) as GameObject;
                newbonusdeath.transform.position = new Vector2(RandomChoiceBonus, ybonus); 
                //Debug.Log("blue bombdeath position: " + newbonusdeath.transform.position);
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
    }
}

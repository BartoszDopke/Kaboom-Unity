using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BomberMove : MonoBehaviour
{
    public float speed = 0.5f;
    public float start_speed = 0.5f;
    public Rigidbody2D rb;
    public GameObject apple;
    public GameObject bomber;
    Vector3 NextPoint;
    public float nMin = -8f;
    public float nMax = 8f;
    public float yStart = 3.37f;

    //tworzy nowy losowy punkt, do którego dochodzi Bomber
    Vector3 GenerateNextPoint(float min, float max)
    {
        return (new Vector3(Random.Range(min, max), 3.37f, yStart));
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

    //metody zmieniające prędkość Bombera oraz częstotliwość zrzutu bomb w zależności od trybu gry
    public void SpawnDelayOnePlayer()
    {
        speed = 0.4f;
        InvokeRepeating("Spawn", 0.5f, 0.4f);
    }
    public void SpawnDelayTwoPlayers()
    {
        speed = 0.8f;
        InvokeRepeating("Spawn", 0.5f, 0.3f);
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
        NextPoint = GenerateNextPoint(nMin, nMax);
        speed = 0.5f;
       
    }


    void Update()
    {

       if (Vector3.Distance(transform.position, NextPoint) > 0.5f) //vector3.distance zwraca mi dystans między a i b
       {
            transform.position = Vector3.Lerp(transform.position* Time.timeScale, NextPoint, speed / 20); //dzięki speed/int zmieniam prędkość zmian pozycji Bombera
       }
       else
       {
            NextPoint = GenerateNextPoint(nMin, nMax);
       }
       Speed_Increase();

    }

}


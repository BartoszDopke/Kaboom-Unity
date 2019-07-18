using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionVSMode : MonoBehaviour
{
    private bool isCollide = false;
    private bool isCollide2 = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            Score.points += 10;
            ScoreVS.points += 10; //dodaje punkty Playerowi1
            if (!isCollide)
            {
                if (GameManagerVSMode.collideWithBomb != null)
                    GameManagerVSMode.collideWithBomb.Invoke();
                isCollide = true;
            }
            Destroy(gameObject);
        } 
    }
}

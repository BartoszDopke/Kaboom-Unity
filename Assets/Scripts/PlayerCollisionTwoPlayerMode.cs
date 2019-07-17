using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionTwoPlayerMode : MonoBehaviour
{
    private bool isCollide = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player" || coll.gameObject.name == "Player2")
        {
            Score.points += 10;
            if (!isCollide)
            {
                if (GameManager.collideWithBomb != null)
                    GameManager.collideWithBomb.Invoke();
                isCollide = true;
            }
            Destroy(gameObject);
        } 
    }
}

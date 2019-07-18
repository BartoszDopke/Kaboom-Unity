using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoCollision : MonoBehaviour
{
    private bool isCollide2 = false;

    void OnCollisionEnter2D(Collision2D coll)
    {     
        if (coll.gameObject.name == "Player2")
        {
            ScorePlayerTwo.points += 10;
            if (!isCollide2)
            {
                if (GameManagerVSMode.collideWithBomb2 != null)
                    GameManagerVSMode.collideWithBomb2.Invoke();
                isCollide2 = true;
            }
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool isCollide = false;
    private bool isCollide2 = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            Score.points += 10;
            ScoreVS.points += 10; //do trybu Versus
            if (!isCollide)
            {
                if (GameManager.collideWithBomb != null)
                    GameManager.collideWithBomb.Invoke();
                isCollide = true;
            }
            Destroy(gameObject);
        }
        if (coll.gameObject.name == "Player2")
        {
            ScorePlayerTwo.points -= 10; //do trybu Versus
            if (!isCollide2)
            {
                if (GameManager.collideWithBomb2 != null)
                    GameManager.collideWithBomb2.Invoke();
                isCollide2 = true;
            }
            Destroy(gameObject);
        }
    }
}


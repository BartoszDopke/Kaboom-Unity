using UnityEngine;

public class BonusPlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player" || coll.gameObject.name == "Player2")
        {           
            if(SpriteChanger.hp < 3)
            {
                SpriteChanger.hp++;
            }
            if (SpriteChanger2.hp2 < 3)
            {
                SpriteChanger2.hp2++;
            }
            Destroy(gameObject);
        }
    }
}


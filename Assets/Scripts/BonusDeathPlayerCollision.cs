using UnityEngine;

public class BonusDeathPlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player" || coll.gameObject.name == "Player2")
        {
            SpriteChanger2.hp2--;
            SpriteChanger.hp--;
            Destroy(gameObject);
        }
    }
}

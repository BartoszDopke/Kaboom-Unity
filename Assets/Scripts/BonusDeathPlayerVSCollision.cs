using UnityEngine;

public class BonusDeathPlayerVSCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            SpriteChangerVSMode.hp--;
            SpriteChanger.hp--;
            Destroy(gameObject);
        }


        if (coll.gameObject.name == "Player2")
        {
            SpriteChanger2VSMode.hp2--;
            Destroy(gameObject);
        }
    }
}

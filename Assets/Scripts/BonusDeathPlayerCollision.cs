using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDeathPlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            Destroy(gameObject);
            SpriteChangerVSMode.hp--; 
        }
        if (coll.gameObject.name == "Player2")
        {
            Destroy(gameObject);
            SpriteChanger2VSMode.hp2--;           
        }
    }
}

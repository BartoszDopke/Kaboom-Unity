using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDeathPlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            Debug.Log("kolizja bomby death z Player");
            Destroy(gameObject);
            SpriteChangerVSMode.hp--; 
        }
        if (coll.gameObject.name == "Player2")
        {
            Debug.Log("kolizja bomby death z Player2");
            Destroy(gameObject);
            SpriteChanger2VSMode.hp2--;           
        }
    }
}

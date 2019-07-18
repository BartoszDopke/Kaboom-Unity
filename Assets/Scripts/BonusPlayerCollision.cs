using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {           
            if (SpriteChangerVSMode.hp < 3)
            {
                Debug.Log("kolizja bonusa z Playerem");
                SpriteChangerVSMode.hp++;
                Debug.Log("hp: " + SpriteChangerVSMode.hp);

            }
            Destroy(gameObject);
        }
        if (coll.gameObject.name == "Player2")
        {         
            if (SpriteChanger2VSMode.hp2 < 3)
            {
                Debug.Log("kolizja bonusa z Playerem2!!!!!!!!!!!");
                SpriteChanger2VSMode.hp2++;
                Debug.Log("hp2: " + SpriteChanger2VSMode.hp2);
            }
            Destroy(gameObject);
        }
    }
}


﻿using UnityEngine;

public class BonusPlayerVSCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            if (SpriteChangerVSMode.hp < 3)
            {
                SpriteChangerVSMode.hp++;
            }
            if (SpriteChanger.hp < 3)
            {
                SpriteChanger.hp++;
            }
            Destroy(gameObject);
        }
       
        if (coll.gameObject.name == "Player2")
        {
                
            if (SpriteChanger2VSMode.hp2 < 3)
            {
                SpriteChanger2VSMode.hp2++;
            }
            Destroy(gameObject);
        }      
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionVSMode : MonoBehaviour
{
    private bool isCollide = false;
    private bool isCollide2 = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            Score.points += 10;
            ScoreVS.points += 10; //dodaje punkty Playerowi1
            if (!isCollide)
            {
                if (GameManagerVSMode.collideWithBomb != null)
                    GameManagerVSMode.collideWithBomb.Invoke();
                isCollide = true;
            }
            Destroy(gameObject);
        }
        if (coll.gameObject.name == "Player2")
        {
            ScorePlayerTwo.points2 -= 10;
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
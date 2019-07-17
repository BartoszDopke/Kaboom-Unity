using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger2VSMode : MonoBehaviour
{
    //zmienne
    public Sprite lives3;
    public Sprite lives2;
    public Sprite lives1;
    public Sprite coll1;
    public Sprite coll2;
    public Sprite coll3;
    public Sprite bomber;
    public Sprite bomberhappy;
    public static int hp2 = 3;
    private bool isOutOfBound = false;
    private bool isCollision = false;


    [SerializeField] public SpriteRenderer mainSprite;
    [SerializeField] public SpriteRenderer BomberSprite;
    [SerializeField] public SpriteRenderer Collision2Sprite;


    //metody od GameManager
    private void OnEnable()
    {
        GameManagerVSMode.bombOutOfBounds2VSMode += ChangePlayer2Sprite;
        GameManagerVSMode.bombOutOfBounds2VSMode += BomberUpdateSprite;
        GameManagerVSMode.collideWithBomb2 += PlayerCollisionUpdateSprite;

    }

    private void OnDisable()
    {
        GameManagerVSMode.bombOutOfBounds2VSMode -= ChangePlayer2Sprite;
        GameManagerVSMode.bombOutOfBounds2VSMode -= BomberUpdateSprite;
        GameManagerVSMode.collideWithBomb2 -= PlayerCollisionUpdateSprite;
    }

    //zmiana sprite'a
    private void ChangePlayer2Sprite()
    {
        hp2--;
        UpdateSprite();
        Debug.Log("hp player2 from SpriteChanger2VSMode: " + hp2);

    }


    private void UpdateSprite()
    {
        switch (hp2)
        {
            case 3:
                mainSprite.sprite = lives3;
                break;
            case 2:
                mainSprite.sprite = lives2;
                break;
            case 1:
                mainSprite.sprite = lives1;
                break;
        }
    }


    //zmiana sprite'a Bombera na krótki czas
    private void BomberUpdateSprite()
    {
        if (!isOutOfBound)
        {
            isOutOfBound = true;
            StartCoroutine(ChangeBombSprite());
        }
        isOutOfBound = false;

    }
    IEnumerator ChangeBombSprite()
    {
        BomberSprite.sprite = bomberhappy;
        yield return new WaitForSeconds(1f);
        BomberSprite.sprite = bomber;
    }

    //zmiana sprite'a Playera2 na krótki czas
    private void PlayerCollisionUpdateSprite()
    {

        if (!isCollision)
        {
            isCollision = true;
            StartCoroutine(ChangeSpriteCollision());
        }
        isCollision = false; 

    }

    IEnumerator ChangeSpriteCollision()
    {
        if (hp2 == 3)
        {
            Collision2Sprite.sprite = coll3;
            yield return new WaitForSeconds(0.3f);
            Collision2Sprite.sprite = lives3;
        }
        else if (hp2 == 2)
        {
            Collision2Sprite.sprite = coll2;
            yield return new WaitForSeconds(0.3f);
            Collision2Sprite.sprite = lives2;
        }
        else if (hp2 == 1)
        {
            Collision2Sprite.sprite = coll1;
            yield return new WaitForSeconds(0.3f);
            Collision2Sprite.sprite = lives1;
        }
    }
}


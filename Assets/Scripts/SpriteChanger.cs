using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    public Sprite lives3;
    public Sprite lives2;
    public Sprite lives1;
    public Sprite coll1;
    public Sprite coll2;
    public Sprite coll3;
    public Sprite bomber;
    public Sprite bomberhappy;
    public static int hp = 3;
    private bool isOutOfBound = false;
    private bool isCollision = false;


    [SerializeField] public SpriteRenderer mainSprite;
    [SerializeField] public SpriteRenderer BomberSprite;
    [SerializeField] public SpriteRenderer CollisionSprite;


    //metody od GameManager
    private void OnEnable()
    {
        GameManager.bombOutOfBounds += ChangePlayerSprite;
        GameManager.bombOutOfBounds += BomberUpdateSprite;
        GameManager.collideWithBomb += PlayerCollisionUpdateSprite;
    }

    private void OnDisable()
    {
        GameManager.bombOutOfBounds -= ChangePlayerSprite;
        GameManager.bombOutOfBounds -= BomberUpdateSprite;
        GameManager.collideWithBomb -= PlayerCollisionUpdateSprite;
    }

    private void ChangePlayerSprite()
    {
        hp--;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        switch (hp)
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

    //zmiana sprite'a Playera na krótki czas
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
        if (hp == 3)
        {
            CollisionSprite.sprite = coll3;
            yield return new WaitForSeconds(0.3f);
            CollisionSprite.sprite = lives3;
        }
        else if (hp == 2)
        {
            CollisionSprite.sprite = coll2;
            yield return new WaitForSeconds(0.3f);
            CollisionSprite.sprite = lives2;
        }
        else if (hp == 1)
        {
            CollisionSprite.sprite = coll1;
            yield return new WaitForSeconds(0.3f);
            CollisionSprite.sprite = lives1;
        }
    }
}


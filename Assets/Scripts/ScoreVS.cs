using UnityEngine;
using UnityEngine.UI;

public class ScoreVS : MonoBehaviour
{
    public Text scoreText;
    public static int points = 0;
    private bool isReached = false;
    public Sprite lives3;
    public Sprite lives2;
    public Sprite lives1;
    public SpriteRenderer mainSprite;
    public SpriteRenderer mainSprite2;

    void Update()
    {
        //aktualizowanie i wyświetlanie obecnego wyniku
        scoreText.text = "Score (Player 1): \n" + points.ToString();

        //instrukcje warunkowe do zmiany sprite'ów przy straceniu/zyskaniu życia oraz każdym kolejnym 1000 punktów
        if (points!=0)
        {
            if (points % 1000 == 0)
            {
                if(!isReached)
                {
                    if (SpriteChanger.hp == 1)
                    {
                        SpriteChanger.hp += 1;                     
                        mainSprite.sprite = lives2;                       
                    }
                    else if (SpriteChanger.hp == 2)
                    {
                        SpriteChanger.hp += 1;
                        mainSprite.sprite = lives3;                        
                    }
                    else if (SpriteChanger.hp == 3)
                    {
                        mainSprite.sprite = lives3;
                    }

                    if(SpriteChanger2.hp2 == 1)
                    {
                        SpriteChanger2.hp2 += 1;
                        mainSprite2.sprite = lives2;
                    }
                    else if (SpriteChanger2.hp2 == 2)
                    {              
                        SpriteChanger2.hp2 += 1;
                        mainSprite2.sprite = lives3;
                    }
                    else if (SpriteChanger2.hp2 == 3)
                    { 
                        mainSprite2.sprite = lives3;
                    }
                    isReached = true;
                }
            }
            else
            {
                isReached = false;
            }
        }    
    }
}



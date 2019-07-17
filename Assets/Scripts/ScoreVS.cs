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

    void Update()
    {
        //aktualizowanie i wyświetlanie obecnego wyniku
        scoreText.text = "Score (Player 1): \n" + points.ToString();
        //instrukcje warunkowe do zmiany sprite'ów przy straceniu/zyskaniu życia oraz każdym kolejnym 1000 punktów
        if (points!=0)
        {
            if (points % 100 == 0)
            {
                if(!isReached)
                {
                    if (SpriteChangerVSMode.hp == 1)
                    {
                        SpriteChangerVSMode.hp += 1;                     
                        mainSprite.sprite = lives2;                       
                    }
                    else if (SpriteChangerVSMode.hp == 2)
                    {
                        SpriteChangerVSMode.hp += 1;
                        mainSprite.sprite = lives3;                        
                    }
                    else if (SpriteChangerVSMode.hp == 3)
                    {
                        mainSprite.sprite = lives3;
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



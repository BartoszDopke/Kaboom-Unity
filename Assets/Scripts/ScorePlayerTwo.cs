using UnityEngine;
using UnityEngine.UI;

public class ScorePlayerTwo : MonoBehaviour
{
    public Text scoreText;
    public static int points = 0;
    public SpriteRenderer mainSprite;
    private bool isReached = false;
    public Sprite lives3;
    public Sprite lives2;
    public Sprite lives1;

    void Update()
    {
        //aktualizowanie i wyświetlanie obecnego wyniku
        scoreText.text = "Score (Player 2): \n" + points.ToString();

        if (points != 0)
        {
            if (points % 100 == 0)
            {
                if (!isReached)
                {
                    if (SpriteChanger2VSMode.hp2 == 1)
                    {
                        SpriteChanger2VSMode.hp2 += 1;
                        mainSprite.sprite = lives2;
                    }
                    else if (SpriteChanger2VSMode.hp2 == 2)
                    {
                        SpriteChanger2VSMode.hp2 += 1;
                        mainSprite.sprite = lives3;
                    }
                    else if (SpriteChanger2VSMode.hp2 == 3)
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


using UnityEngine;
using UnityEngine.UI;

public class ScorePlayerTwo : MonoBehaviour
{
    public Text scoreText;
    public static int points = 0;
    private bool isReached = false;

    void Update()
    {
        //aktualizowanie i wyświetlanie obecnego wyniku
        scoreText.text = "Score (Player 2): \n" + points.ToString();

        if (points != 0)
        {
            if (points % 200 == 0)
            {
                if (!isReached)
                {
                    SpriteChanger2VSMode.hp2++;
                    if (SpriteChanger2VSMode.hp2 >= 3)
                    {
                        SpriteChanger2VSMode.hp2 = 3;
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


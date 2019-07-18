using UnityEngine;
using UnityEngine.UI;

public class ScoreVS : MonoBehaviour
{
    public Text scoreText;
    public static int points = 0;
    private bool isReached = false;

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
                    SpriteChangerVSMode.hp++;
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



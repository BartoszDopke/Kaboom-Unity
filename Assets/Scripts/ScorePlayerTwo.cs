using UnityEngine;
using UnityEngine.UI;

public class ScorePlayerTwo : MonoBehaviour
{
    public Text scoreText;
    public static int points2 = 0;
    //private bool isReached = false;
    //public Sprite lives3;
    //public Sprite lives2;
    //public Sprite lives1;
    

    void Update()
    {
        //aktualizowanie i wyświetlanie obecnego wyniku
        scoreText.text = "Score (Player 2): \n" + points2.ToString();
        
    }
}

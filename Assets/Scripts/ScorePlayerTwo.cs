using UnityEngine;
using UnityEngine.UI;

public class ScorePlayerTwo : MonoBehaviour
{
    public Text scoreText;
    public static int points2 = 0;
    
    

    void Update()
    {
        //aktualizowanie i wyświetlanie obecnego wyniku
        scoreText.text = "Score (Player 2): \n" + points2.ToString();
        
    }
}

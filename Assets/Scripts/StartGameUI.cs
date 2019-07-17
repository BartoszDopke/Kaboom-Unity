using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartGameUI : MonoBehaviour
{
    //powrót do menu
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    //ładowanie sceny dla jednego gracza
    public void OnePlayerGameStart()
    {
        SceneManager.LoadScene(1);

    }
    //ładowanie sceny dla dwóch graczy kooperacja
    public void TwoPlayerGameStart()
    {
        SceneManager.LoadScene(2);

    }
    //ładowanie sceny dla dwóch graczy rywalizacja
    public void CompTwoPlayerGameStart()
    {
        SceneManager.LoadScene(3);

    }
    
    public void SwitchTwoPlayers()
    {
        SceneManager.LoadScene(3);
    }

    public void TwoPlayerVersus()
    {
        SceneManager.LoadScene(4);
        ScoreVS.points = 0;
        SpriteChangerVSMode.hp = 3;
        SpriteChanger2VSMode.hp2 = 3;
    }
}

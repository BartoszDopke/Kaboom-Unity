using UnityEngine.UI;
using UnityEngine;

public class GameManagerVSMode : MonoBehaviour
{
    public static System.Action bombOutOfBoundsVSMode;
    public static System.Action bombOutOfBounds2VSMode;
    public static System.Action collideWithBomb; //dla pierwszego gracza
    public static System.Action collideWithBomb2; //dla drugiego gracza
    public bool isEnd = false;
    public GameObject player, player2;

    [SerializeField]
    private GameObject gameOverUI;
    public GameObject Player1Win, Player2Win, Draw;

    public void EndGame()
    {
        gameOverUI.SetActive(true);
        if(ScoreVS.points > ScorePlayerTwo.points)
        {
            Player1Win.SetActive(true);
        }
        else if(ScoreVS.points < ScorePlayerTwo.points)
        {
            Player2Win.SetActive(true);
        }
        else
        {
            Draw.SetActive(true);
        }
        Time.timeScale = 0;          
    }

    void Update()
    {
        if(SpriteChangerVSMode.hp <= 0)
        {
            player.GetComponent<PlayerMove>().enabled = false;
            player.GetComponent<Collider2D>().enabled = false;
        }
        if (SpriteChanger2VSMode.hp2 <= 0)
        {
            player2.GetComponent<Player2Move>().enabled = false;
            player2.GetComponent<Collider2D>().enabled = false;
        }

        if (SpriteChangerVSMode.hp <= 0 && SpriteChanger2VSMode.hp2 <= 0)
        {
            if (!isEnd)
            {
                EndGame();
            }
            isEnd = true;
            SpriteChangerVSMode.hp = 0;
            SpriteChanger2VSMode.hp2 = 0;          
        }
    }

    void Start()
    {
        ScoreVS.points = 0;
        ScorePlayerTwo.points = 0;
        Time.timeScale = 1;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static System.Action bombOutOfBounds;
    public static System.Action collideWithBomb;
    public static System.Action collideWithBomb2;
    public bool isEnd = false;
    public Image gameOverImage;
    public GameObject player, player2;
    public Text GameOverText, ExitText, PlayText, MenuStartText;
    public Image PlayButton, ExitButton, MenuStartButton;

    [SerializeField]
    private GameObject gameOverUI;

    public void EndGame()
    {
        player.GetComponent<PlayerMove>().enabled = false;
        player2.GetComponent<Player2Move>().enabled = false;
        Time.timeScale = 0;
        Debug.Log("GAME OVER!");
        gameOverUI.SetActive(true);
    }

    void Update()
    {
        if (SpriteChanger.hp <= 0)
        {
            player.GetComponent<PlayerMove>().enabled = false;
        }
        if (SpriteChanger2.hp2 <= 0)
        {
            player2.GetComponent<Player2Move>().enabled = false;
        }
        if (SpriteChanger.hp <= 0)
        {
            if (!isEnd)
            {
                EndGame();
            }
            isEnd = true;
            SpriteChanger.hp = 0;
            SpriteChanger2.hp2 = 0;
            
        }
    }

    void Start()
    {
        Score.points = 0;
        ScorePlayerTwo.points = 0;
        Time.timeScale = 1;
        player.GetComponent<PlayerMove>().enabled = true;
        player2.GetComponent<Player2Move>().enabled = true;  
    }
}

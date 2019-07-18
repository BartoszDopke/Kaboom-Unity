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
    public Image gameOverImage;
    public Text GameOverText, ExitText, PlayText, MenuStartText;
    public Image PlayButton, ExitButton, MenuStartButton;

    [SerializeField]
    private GameObject gameOverUI;

    public void EndGame()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;      
        Debug.Log("GAME OVER!");       
    }

    void Update()
    {
        if(SpriteChangerVSMode.hp <= 0)
        {
            player.GetComponent<PlayerMove>().enabled = false;
        }
        if (SpriteChanger2VSMode.hp2 <= 0)
        {
            player2.GetComponent<Player2Move>().enabled = false;
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
        player.GetComponent<PlayerMove>().enabled = true;
        player2.GetComponent<Player2Move>().enabled = true;
    }
}

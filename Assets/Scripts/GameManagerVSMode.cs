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
        Time.timeScale = 0;
        Debug.Log("GAME OVER!");
        gameOverUI.SetActive(true);
        gameOverImage.enabled = true;
        GameOverText.enabled = true;
        ExitText.enabled = true;
        PlayText.enabled = true;
        MenuStartText.enabled = true;
        PlayButton.enabled = true;
        ExitButton.enabled = true;
        MenuStartButton.enabled = true;
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
            ScoreVS.points = 0;
            ScorePlayerTwo.points2 = 0;
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        player.GetComponent<PlayerMove>().enabled = true;
        player2.GetComponent<Player2Move>().enabled = true;
        gameOverImage.enabled = false;
        GameOverText.enabled = false;
        ExitText.enabled = false;
        PlayText.enabled = false;
        MenuStartText.enabled = false;
        PlayButton.enabled = false;
        ExitButton.enabled = false;
        MenuStartButton.enabled = false;
    }
}

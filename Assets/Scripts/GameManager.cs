using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static System.Action bombOutOfBounds;
    public static System.Action bombOutOfBounds2;
    public static System.Action collideWithBomb;
    public static System.Action collideWithBomb2;
    public bool isEnd = false;
    public GameObject player, player2;

    [SerializeField]
    private GameObject gameOverUI;

    public void EndGame()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    void Update()
    {
        if (SpriteChanger.hp <= 0)
        {
            player.GetComponent<PlayerMove>().enabled = false;
            player2.GetComponent<Player2Move>().enabled = false;
        }
        if (SpriteChanger2.hp2 <= 0)
        {
            player.GetComponent<PlayerMove>().enabled = false;
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
    }
}

﻿using UnityEngine;
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
            Score.points = 0;
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

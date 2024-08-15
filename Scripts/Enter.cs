using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    [SerializeField] GameObject start, exit ,gameName, player,spawner,scoreText, restart,exit2,highScoreText;
    [SerializeField]Rigidbody2D playerRb;

 

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Çýkýþ Yapýldý");
    }
    public void StartGame()
    {   
        exit.SetActive(false);
        gameName.SetActive(false);
        spawner.SetActive(true);
        scoreText.SetActive(true);
        start.SetActive(false);
        highScoreText.SetActive(false);
    }

    public void RestartGame()
    {
        SquareMove.jump = 8.5f;
        playerRb.gravityScale = 2.5f;
        SquareMove._score = 0;
        restart.SetActive(false);
        exit2 .SetActive(false);
        highScoreText.SetActive(false);
        Time.timeScale = 1;
        player.transform.position = new Vector2(-1.2f, -4f);      
    }
}

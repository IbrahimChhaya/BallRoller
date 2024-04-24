using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameStarted = false;
    bool gameOver = false;
    int score;
    int highScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
        highScore = PlayerPrefs.GetInt("highScore", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // start the game
    public void gameStart()
    {
        gameStarted = true;
        // start tracking the score
        startScore();
        // start spawning the platforms
        gameObject.GetComponent<PlatformSpawner>().startSpawning();
    }

    public void gameEnd()
    {
        gameOver = true;
        // stop the score
        // show the game over panel
        // show the restart button
    }

    public void startScore()
    {
        // start counting score after 1 second
        InvokeRepeating("incrementScore", 1.0f, 0.5f);
    }

    void incrementScore()
    {
        if (!gameOver)
        {
            score++;
        }
    }

    public void stopScore()
    {
        CancelInvoke("incrementScore");
        // save the score
        PlayerPrefs.SetInt("score", score);
        // check if the score is greater than the high score
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public bool isGameStarted()
    {
        return gameStarted;
    }

    public bool isGameOver() {
        return gameOver;
    }
}

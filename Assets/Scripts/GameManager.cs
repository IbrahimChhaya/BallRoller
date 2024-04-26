using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameStarted = false;
    bool gameOver = false;
    int score;

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

    }

    // Update is called once per frame
    void Update()
    {

    }

    // start the game
    public void gameStart()
    {
        gameStarted = true;
        // hide gui
        gameObject.GetComponent<UiManager>().showGameStart();
        // start tracking the score
        startScore();
        // start spawning the platforms
        gameObject.GetComponent<PlatformSpawner>().startSpawning();
    }

    public void startScore()
    {
        // start counting score after 1 second
        InvokeRepeating("incrementScore", 0.1f, 0.5f);
    }

    void incrementScore()
    {
        if (!gameOver)
        {
            score++;
        }
    }

    public void gameEnd()
    {
        gameOver = true;
        // stop the score
        stopScore();
        // show gui
        gameObject.GetComponent<UiManager>().showGameOver();
        // stop spawning the platforms
        gameObject.GetComponent<PlatformSpawner>().stopSpawning();
    }

    public void stopScore()
    {
        CancelInvoke("incrementScore");
        // check if the score is greater than the high score
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }

    public bool isGameStarted()
    {
        return gameStarted;
    }

    public bool isGameOver()
    {
        return gameOver;
    }

    public int getScore()
    {
        return score; 
    }

    public void scoreMultiplier()
    {
        score += 20;
    }
}

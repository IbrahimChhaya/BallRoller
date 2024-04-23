using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameStarted = false;
    bool gameOver = false;
    int score = 0;

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
        // start tracking the score
        startScore();
        // start spawning the platforms
        gameObject.GetComponent<PlatformSpawner>().startSpawning();
    }

    void startScore()
    {
        // start the score
        // coroutines or invoke repeating? consider optimisation, may need to change other scripts
    }

    public bool isGameStarted()
    {
        return gameStarted;
    }
}

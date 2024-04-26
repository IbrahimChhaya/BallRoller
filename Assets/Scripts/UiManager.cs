using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    public GameObject gameName;

    public GameObject tapToPlay;

    public GameObject highScore;

    public GameObject gameOver;

    public GameObject score;

    public GameObject best;

    public GameObject tapToReplay;

    public GameObject runningScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.GetComponent<TextMeshProUGUI>().text = "High Score: " 
                                                        + PlayerPrefs.GetInt("highScore", 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (runningScore.activeSelf)
        {
            runningScore.GetComponent<TextMeshProUGUI>().text = "SCORE: " + GameManager.instance.getScore().ToString();
        }
        if (tapToPlay.activeSelf)
        {
            tapToPlay.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 0, 0.654902f, Mathf.PingPong(Time.time, 1));
        }
        if (tapToReplay.activeSelf)
        {
            tapToReplay.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 0, 0.654902f, Mathf.PingPong(Time.time, 1));
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.y > 75f)
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }

    public void showGameHome()
    {
        gameName.SetActive(true);
        tapToPlay.SetActive(true);
        highScore.SetActive(true);
        runningScore.SetActive(false);
    }

    public void showGameStart()
    {
        gameName.SetActive(false);
        tapToPlay.SetActive(false);
        highScore.SetActive(false);
        runningScore.SetActive(true);
    }

    public void showGameOver()
    {
        gameOver.SetActive(true);
        score.SetActive(true);
        score.GetComponent<TextMeshProUGUI>().text = "SCORE" + Environment.NewLine + GameManager.instance.getScore().ToString();
        best.SetActive(true);
        best.GetComponent<TextMeshProUGUI>().text = "BEST" + Environment.NewLine 
                                                    + PlayerPrefs.GetInt("highScore", GameManager.instance.getScore()).ToString();
        tapToReplay.SetActive(true);
        runningScore.SetActive(false);
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //UI components

    public GameObject gameName;

    public GameObject tapToPlay;

    public GameObject highScore;

    public GameObject gameOver;

    public GameObject score;

    public GameObject best;

    public GameObject tapToReplay;

    public GameObject runningScore;

    public GameObject tapButton;

    //background music

    public GameObject soundButton;

    public Sprite soundOn;

    public Sprite soundOff;

    bool mute;

    public GameObject backgroundMusic;

    //selection

    public GameObject skinButton;

    public GameObject selection;

    public GameObject cubeSelector;

    public GameObject sphereSelector;

    // Start is called before the first frame update
    void Start()
    {
        highScore.GetComponent<TextMeshProUGUI>().text = "High Score: " 
                                                        + PlayerPrefs.GetInt("highScore", 0);
        mute = Convert.ToBoolean(PlayerPrefs.GetInt("mute", 0));
        if (!mute)
        {
            // if not muted, then mute
            soundButton.GetComponent<Image>().sprite = soundOn;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOff;
        }
        backgroundMusic.GetComponent<AudioSource>().mute = mute;

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
        soundButton.SetActive(true);
        runningScore.SetActive(false);
    }

    public void showGameStart()
    {
        gameName.SetActive(false);
        tapToPlay.SetActive(false);
        highScore.SetActive(false);
        soundButton.SetActive(false);
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

    public void soundOnOff()
    {
        if (!mute)
        {
            // if not muted, then mute
            soundButton.GetComponent<Image>().sprite = soundOff;
            mute = true;
            PlayerPrefs.SetInt("mute", Convert.ToInt32(mute));
        }
        else
        {
            // if muted, unmute
            mute = false;
            soundButton.GetComponent<Image>().sprite = soundOn;
            PlayerPrefs.SetInt("mute", Convert.ToInt32(mute));
        }
        backgroundMusic.GetComponent<AudioSource>().mute = mute;
    }

    public void selectSkinButton()
    {
        //enable animation to move camera right
        //enable disabled game objects
        selection.SetActive(true);
        cubeSelector.SetActive(true);
        sphereSelector.SetActive(true);

        //disable UI components
        gameName.SetActive(false);
        tapToPlay.SetActive(false);
        highScore.SetActive(false);
        soundButton.SetActive(false);
        skinButton.SetActive(false);
        tapButton.SetActive(false);
    }
}

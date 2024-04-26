using TMPro;
using UnityEngine;

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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showGameHome()
    {
        gameName.SetActive(true);
        tapToPlay.SetActive(true);
        highScore.SetActive(true);
        runningScore.SetActive(false);

        tapToPlay.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 0, 0.654902f, Mathf.PingPong(Time.time, 1));
    }

    public void showGameStart()
    {
        gameName.SetActive(false);
        tapToPlay.SetActive(false);
        highScore.SetActive(false);
        runningScore.SetActive(false);
    }

    public void showGameOver()
    {
        gameOver.SetActive(true);
        score.SetActive(true);
        best.SetActive(true);
        tapToReplay.SetActive(true);
        runningScore.SetActive(false);
    }
}

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameStarted())
        {
            gameName.SetActive(false);
            tapToPlay.SetActive(false);
            highScore.SetActive(false);
        }
        // if game is not started, show the game name and tap to play
        // animate tap to play by fading in and out by changing transparancy of the tapToPlay TextMeshPro
        else
        {
            gameName.SetActive(true);
            tapToPlay.SetActive(true);
            highScore.SetActive(true);

            tapToPlay.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 0, 0.654902f, Mathf.PingPong(Time.time, 1));
            Debug.Log(Time.time);
        }

        if (GameManager.instance.isGameOver())
        {
            gameOver.SetActive(true);
            score.SetActive(true);
            best.SetActive(true);
            tapToReplay.SetActive(true);

            //score.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + GameManager.instance.getScore();
            //best.GetComponent<TMPro.TextMeshProUGUI>().text = "Best: " + GameManager.instance.getBest();
        }
        else
        {
            gameOver.SetActive(false);
            score.SetActive(false);
            best.SetActive(false);
            tapToReplay.SetActive(false);
        }
    }
}

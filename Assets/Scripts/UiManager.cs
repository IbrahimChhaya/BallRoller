using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{

    public GameObject gameName;
    
    public GameObject tapToPlay;
    
    public GameObject highScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameStarted())
        {
            gameName.SetActive(false);
            tapToPlay.SetActive(false);
            highScore.SetActive(false);
        } else
        {
            // blink the tap to play text by changing the alpha value of the text
            tapToPlay.SetActive(true);
            tapToPlay.color.a = Mathf.PingPong(Time.time, 1);
            tapToPlay.
            highScore.SetActive(true);
        }
    }
}

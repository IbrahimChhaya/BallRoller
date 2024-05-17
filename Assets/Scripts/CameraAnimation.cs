using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{

    public GameObject cubeSelector;

    public GameObject sphereSelector;

    public GameObject highScore;

    public GameObject skinButton;

    public GameObject tapToPlay;

    public GameObject tapButton;

    public GameObject playButton;

    public GameObject selection;

    public GameObject mainCamera;

    public GameObject cubeButton;

    public GameObject sphereButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void enableSelectorGui()
    {
        cubeSelector.SetActive(true);
        sphereSelector.SetActive(true);
    }

    void disableSelectorGui()
    {
        highScore.SetActive(true);
        skinButton.SetActive(true);
        tapToPlay.SetActive(true);
        tapButton.SetActive(true);

        playButton.SetActive(false);
        selection.SetActive(false);
    }
}

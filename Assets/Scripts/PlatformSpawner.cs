using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public GameObject extendedPlatform1;

    public GameObject extendedPlatform2;

    Vector3 position;

    float size;

    // Start is called before the first frame update
    void Start()
    {
        // enable the extended platforms
        extendedPlatform1.SetActive(true);
        extendedPlatform2.SetActive(true);
        // get the position and size of the prefab platform
        position = platform.transform.position;
        size = platform.transform.localScale.x;

        // spawn 10 platforms at the start of the game
        for (int i = 0; i < 10; i++)
        {
            spawnPlatform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnPlatform()
    {
        // generate a random number between 0 and 6
        int rand = Random.Range(0, 6);

        // if the random number is less than 3, spawn the platform on the x-axis
        // otherwise, spawn the platform on the z-axis
        if (rand < 3)
        {
            spawnAxis('x');
        }
        else
        {
            spawnAxis('z');
        }
    }

    void spawnAxis(char axis)
    {
        // get the position of the prefab platform
        Vector3 pos = position;
        // if the axis is x, then increment the x position by the size of the platform
        if (axis == 'x')
        {
            pos.x += size;
        }
        // if the axis is z, then increment the z position by the size of the platform
        else if (axis == 'z')
        {
            pos.z += size;
        }
        // instantiate the platform at the new position
        Instantiate(platform, pos, Quaternion.identity);
        // set the position of the platform to the new position
        position = pos;
    }

    public void startSpawning()
    {
        // start spawning the platforms
        InvokeRepeating("spawnPlatform", 0.1f, 0.2f);
    }
}

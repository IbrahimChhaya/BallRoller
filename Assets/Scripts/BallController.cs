using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallController : MonoBehaviour
{
    public float speed = 6;
    public bool started = false;
    Rigidbody rb;
    Vector3 vector3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if game is not started, wait for the player to click the mouse button (or tap the screen in our case)
        // then start the game
        if (!started)
        {
            // won't this be too sensitive on phones? what if swipe down to open notifs?
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.y > 75f)
            {
                // add force to the ball
                rb.velocity = new Vector3(0, 0, speed);
                vector3 = rb.velocity;
                started = true;
                GameManager.instance.gameStart();
            }
        }
        else
        {
            // draw a ray to see if the ball is falling off the platform
            Debug.DrawRay(transform.position, Vector3.down, Color.red);

            // if the ball falls off the platform, then game over
            if (!Physics.Raycast(transform.position, Vector3.down, 1f))
            {
                // reset the camera's parent to null so that the camera doesn't follow the ball anymore
                Camera.main.transform.SetParent(null);
                // game over
                started = false;
                GameManager.instance.gameEnd();
                // drop it like it's hot
                rb.velocity = new Vector3(0, -25f, 0);
                // destroy the ball after 2 seconds to free up memory
                Destroy(gameObject, 2f);
            }

            // if the player clicks the mouse button (or tap the screen in our case), then switch the direction of the ball
            if (Input.GetMouseButtonDown(0) && started && Input.mousePosition.y > 75f)
            {
                SwitchDirection();
            }
        }
    }

    void SwitchDirection()
    {
        // add code to change speed based on score
        // make it so that the speed gets faster as the score increases


        // if the ball is moving in the z direction, then move it in the x direction
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        // else if the ball is moving in the x direction, then move it in the z direction
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
        vector3 = rb.velocity;

        int score = GameManager.instance.getScore();
        if (score >= 4000)
            speed = 10;
        else if (score >= 3000)
            speed = 9;
        else if (score >= 2000)
            speed = 8;
        else if (score >= 1000)
            speed = 7;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            GameManager.instance.scoreMultiplier();
            Destroy(collision.gameObject);
            rb.velocity = vector3;
        }
    }
}

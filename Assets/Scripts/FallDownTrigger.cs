using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        // once the ball exits the trigger, enable gravity on the platform
        // and destroy the platform after 1.5 seconds
        if (col.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(gameObject, 1.5f);
        }
    }
}

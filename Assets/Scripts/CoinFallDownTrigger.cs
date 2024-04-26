using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFallDownTrigger : MonoBehaviour
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
            GetComponentInParent<Rigidbody>().useGravity = true;
            GetComponentInParent<Rigidbody>().isKinematic = false;
            Destroy(gameObject.transform.parent.gameObject, 1.5f);
        }
    }
}

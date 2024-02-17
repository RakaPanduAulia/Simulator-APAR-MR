using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndGrabBall : MonoBehaviour
{
    public GameObject prefab;
    public float spawnSpeed = 5f;
    private GameObject currentBall;
    private bool isGrabbing = false;

    // Update is called once per frame
    void Update()
    {
        // Spawn a ball when the index trigger is pressed
        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !isGrabbing)
        {
            currentBall = Instantiate(prefab, transform.position, Quaternion.identity);
            Rigidbody rb = currentBall.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * spawnSpeed;
        }

        // Grab the ball when the hand trigger is pressed
        if(OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            if (currentBall != null)
            {
                currentBall.GetComponent<Rigidbody>().isKinematic = true;
                currentBall.transform.SetParent(transform);
                isGrabbing = true;
            }
        }

        // Release the ball when the hand trigger is released
        if(OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            if (currentBall != null)
            {
                currentBall.GetComponent<Rigidbody>().isKinematic = false;
                currentBall.transform.SetParent(null);
                currentBall = null;
                isGrabbing = false;
            }
        }
    }
}

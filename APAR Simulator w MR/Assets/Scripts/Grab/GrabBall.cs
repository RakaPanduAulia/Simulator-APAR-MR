using UnityEngine;

public class GrabBall : MonoBehaviour
{
    private GameObject grabbedObject = null;
    private bool isGrabbing = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the hand trigger is pressed and we are not already grabbing something
        if(OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) && !isGrabbing)
        {
            // Perform a raycast or check for collision to find the object to grab
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                // Check if the hit object is the ball
                if (hit.transform.gameObject.CompareTag("Ball"))
                {
                    grabbedObject = hit.transform.gameObject;
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                    grabbedObject.transform.SetParent(transform);
                    isGrabbing = true;
                }
            }
        }

        // Check if the hand trigger is released and we are currently grabbing something
        if(OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) && isGrabbing)
        {
            // Release the grabbed object
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
            isGrabbing = false;
        }
    }
}

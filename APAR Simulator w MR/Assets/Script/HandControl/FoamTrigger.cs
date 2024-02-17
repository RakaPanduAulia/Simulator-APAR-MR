using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoamTrigger : MonoBehaviour
{
    public FoamEmitter leftHandFoamEmitter;

    private bool triggerPressed = false;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            leftHandFoamEmitter.EmitFoam();
        }

        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            leftHandFoamEmitter.StopFoam();
        }
    }
}

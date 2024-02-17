using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoamEmitter : MonoBehaviour
{
    public ParticleSystem foamParticleSystem;

    void Update ()
    {
        transform.position = transform.parent.position;
    }

    public void EmitFoam()
    {
        foamParticleSystem.Play();
    }

    public void StopFoam()
    {
        foamParticleSystem.Stop();
    }
}

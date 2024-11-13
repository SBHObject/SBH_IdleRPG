using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickParticle : MonoBehaviour
{
    public ParticleSystem particle;
    public Camera uiCam;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            particle.transform.position = uiCam.ScreenToWorldPoint(Input.mousePosition);
            particle.Play();
        }
    }
}

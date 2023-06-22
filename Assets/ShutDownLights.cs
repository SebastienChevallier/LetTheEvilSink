using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDownLights : MonoBehaviour
{
    public GameObject lights;

    private void OnTriggerEnter(Collider other)
    {
        lights.SetActive(false);
    }
}

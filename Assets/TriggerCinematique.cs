using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCinematique : MonoBehaviour
{
    public GameObject cinematique;
    private bool cinematiquePlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !cinematiquePlayed)
        {
            cinematique.SetActive(true);
            cinematiquePlayed = true;
        }
    }
}

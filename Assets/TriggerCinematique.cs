using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCinematique : MonoBehaviour
{
    public GameObject cinematique;
    private bool cinematiquePlayed = false;

    public Trigger_Minijeu triggerMinijeu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !cinematiquePlayed)
        {
            if (triggerMinijeu)
            {
                if (!triggerMinijeu.validated) return;
            }
            cinematique.SetActive(true);
            cinematiquePlayed = true;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllumageGenerateur : MonoBehaviour
{
    public Trigger_Minijeu miniJeu;
    private bool isOn = false;
    public GameObject lights;

    private void Update()
    {
        if (miniJeu.validated && !isOn)
        {
            lights.SetActive(true);
            isOn = true;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCarnet : MonoBehaviour
{
    public So_ObjectifsCarnet _ObjectifsCarnet;
    public string _NomCarnet;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact") && other.CompareTag("Player"))
        {
            _ObjectifsCarnet.SetCarnet(_NomCarnet);
        }
            
    }
}

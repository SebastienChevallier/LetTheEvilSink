using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Minijeu : MonoBehaviour
{
    public So_Player _player;
    public GameObject _canvaMinijeu;
    public GameObject triggerPorte;

    public bool validated;
    private bool _isTrigger = false;

    private void Start()
    {
        _canvaMinijeu.SetActive(false);
        triggerPorte.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && !_canvaMinijeu.activeSelf && !validated && _isTrigger)
        {
            _player._CanMove = false;
            _canvaMinijeu.SetActive(true);
        }

        if (_canvaMinijeu.activeSelf && validated)
        {
            _player._CanMove = true;
            _canvaMinijeu.SetActive(false);
            triggerPorte.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isTrigger = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isTrigger = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}

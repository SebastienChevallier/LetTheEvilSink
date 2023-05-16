using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Minijeu : MonoBehaviour
{
    public So_Player _player;
    public GameObject _canvaMinijeu;
    public GameObject triggerPorte;
    private WireTask _wireTask;

    public bool validated;
    private bool _isTrigger = false;

    public CreatureStateManager creature;

    private void Start()
    {
        _canvaMinijeu.SetActive(false);
        triggerPorte.SetActive(false);
        _wireTask = _canvaMinijeu.GetComponentInChildren<WireTask>();
        //creature = GameObject.FindWithTag("Creature").GetComponent<CreatureStateManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && !_canvaMinijeu.activeSelf && !validated && _isTrigger)
        {
            _player._CanMove = false;
            _canvaMinijeu.SetActive(true);
            //zcreature.AddGauge(5);
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
        if (other.CompareTag("Player") && _wireTask != null)
        {
            validated = _wireTask.IsTaskCompleted;
        }
    }
}

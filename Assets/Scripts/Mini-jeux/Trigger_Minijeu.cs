using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger_Minijeu : MonoBehaviour
{
    public So_Player _player;
    public GameObject _canvaMinijeu;
    public GameObject triggerPorte;
    private WireTask _wireTask;

    public bool validated;
    private bool _isTrigger = false;
    public bool needCard = false;

    public CreatureStateManager creature;

    private void Start()
    {
        _canvaMinijeu.SetActive(false);
        triggerPorte.SetActive(false);
        _wireTask = _canvaMinijeu.GetComponentInChildren<WireTask>();
        creature = GameObject.FindWithTag("Creature").GetComponent<CreatureStateManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && !_canvaMinijeu.activeSelf && !validated && _isTrigger)
        {
            Player_Movements.Instance.planeAnimator.SetFloat("Speed", 0);
            if (needCard && _player.hasCard)
            {
                _player._CanMove = false;
                _canvaMinijeu.SetActive(true);
                creature.AddGauge(10);
            }
            else if (!needCard)
            {
                _player._CanMove = false;
                _canvaMinijeu.SetActive(true);
                creature.AddGauge(10);
            }
        }

        if (_canvaMinijeu.activeSelf && validated)
        {
            StartCoroutine(EndMiniGame());
        }
    }
    
    IEnumerator EndMiniGame()
    {
        yield return new WaitForSeconds(1f);
        _player._CanMove = true;
        _canvaMinijeu.SetActive(false);
        triggerPorte.SetActive(true);
        this.GameObject().SetActive(false);
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

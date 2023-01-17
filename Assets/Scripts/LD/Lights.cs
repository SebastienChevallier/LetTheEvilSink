using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public So_Player _playerData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _playerData._InDark = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
            _playerData._InDark = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if(_playerData._CanLight && other.CompareTag("Player"))
            _playerData._InDark = true;
    }
}

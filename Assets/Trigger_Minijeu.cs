using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Minijeu : MonoBehaviour
{
    public So_Player _player;
    public GameObject _canvaMinijeu;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetButtonDown("Interact") && !_canvaMinijeu.activeSelf)
        {
            _player._CanMove = false;
            _canvaMinijeu.SetActive(true);
        }

        if (_canvaMinijeu.activeSelf && Input.GetButtonDown("Interact"))
        {
            _player._CanMove = true;
            _canvaMinijeu.SetActive(false);
        }
    }
}

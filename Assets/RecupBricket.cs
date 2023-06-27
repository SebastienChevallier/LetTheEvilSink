using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecupBricket : MonoBehaviour
{
    public So_Player _Player;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            _Player.hasBricket = true;
            //_Player._CanMove = false;
            isTriggered = true;
            StartCoroutine(ChangeText());
        }


    }

    IEnumerator ChangeText()
    {
        RappelObjectif.Instance.Recup("Briquet recupéré");
        RappelObjectif.Instance.tutoBriquet.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        RappelObjectif.Instance.tutoBriquet.gameObject.SetActive(false);
        RappelObjectif.Instance.Recup("");
    }
}

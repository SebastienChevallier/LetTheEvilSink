using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecupBricket : MonoBehaviour
{
    public So_Player _Player;
    private bool isTriggered = false;

    public GameObject _LampeTorche;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            _Player.hasBricket = true;
            _Player._InDark = false;
            _Player._CanLight = false;
            _LampeTorche.SetActive(true);
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

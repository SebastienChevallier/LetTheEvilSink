
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperationCarte : MonoBehaviour
{
    public So_Player _Player;
    public string textToShow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetCard();
        }
    }

    public void GetCard()
    {
        _Player.hasCard = true;
        StartCoroutine(ChangeText());
    }

    IEnumerator ChangeText()
    {
        RappelObjectif.Instance.Recup(textToShow);
        yield return new WaitForSeconds(3f);
        RappelObjectif.Instance.Recup("");
    }
}

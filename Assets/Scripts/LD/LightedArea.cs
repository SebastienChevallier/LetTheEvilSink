using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightedArea : MonoBehaviour
{
    public So_Player _PlayerData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) _PlayerData._InDark = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) _PlayerData._InDark = true;
    }
}

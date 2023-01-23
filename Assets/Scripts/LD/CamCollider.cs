using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCollider : MonoBehaviour
{
    public So_Player _Player;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _Player._CibleCamera = transform.GetChild(0).gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _Player._CibleCamera = GameObject.Find("Player");
        }
    }
}

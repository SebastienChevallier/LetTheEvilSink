using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCheckpoint : MonoBehaviour
{
    public Portes portes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckPointsManager.Instance.lastCheckPoint = transform.gameObject;
            portes.cantBeTaken = true;
        }
    }
}

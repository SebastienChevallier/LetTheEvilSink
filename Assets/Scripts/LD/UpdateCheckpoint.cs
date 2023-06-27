using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCheckpoint : MonoBehaviour
{
    public Porte porte;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckPointsManager.Instance.lastCheckPoint = transform.gameObject;
            porte.cantBeTaken = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSwitch : MonoBehaviour
{
   
       


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            transform.parent.GetComponent<Switchsalle>().obj = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.GetComponent<Switchsalle>().obj = null;
            GetComponentInParent<Switchsalle>().isTriggered = false;
        }
            
    }
}

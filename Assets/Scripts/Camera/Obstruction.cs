using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstruction : MonoBehaviour
{
    public Transform target, obstruction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            obstruction = other.transform;
            obstruction.gameObject.layer = LayerMask.NameToLayer("DontShow");
            for(int i = 0; i < other.transform.childCount; i++)
            {
                other.transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer("DontShow");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            obstruction = other.transform;
            //obstruction.gameObject.layer = LayerMask.NameToLayer("DontShow");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            obstruction = other.transform;
            for(int i = 0; i < other.transform.childCount; i++)
            {
                other.transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer("Default");
            }
        }
    }
    
    void Start()
        {
            obstruction = target;
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
        }
}

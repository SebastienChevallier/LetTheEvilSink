using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{  
    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            transform.parent.GetComponent<Portes>().player = other.gameObject;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.GetComponent<Portes>().player = null;
        }
    }   

}

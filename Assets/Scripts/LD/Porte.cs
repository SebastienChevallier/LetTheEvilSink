using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    public Transform parent;

    public Portes portes;
    public string nomSalle = "";

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            FadeManager.Instance.ChangeText(nomSalle);
            transform.parent.GetComponent<Portes>().player = other.gameObject;
            if (transform == parent.GetChild(0))
            {
                portes.frontTriggered = true;
                portes.backTriggered = false;
            }

            else if (transform == parent.GetChild(1))
            {
                portes.frontTriggered = false;
                portes.backTriggered = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.GetComponent<Portes>().player = null;
            if (transform == parent.GetChild(0))
            {
                portes.frontTriggered = false;
                portes.backTriggered = false;
            }

            else if (transform == parent.GetChild(1))
            {
                portes.frontTriggered = false;
                portes.backTriggered = false;
            }
        }
    }   

}

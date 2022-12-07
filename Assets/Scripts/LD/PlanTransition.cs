using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanTransition : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetButtonDown("Interact"))
        {
            other.transform.position = new Vector3(transform.GetChild(0).transform.position.x, other.transform.position.y, transform.GetChild(0).transform.position.z);
        }
    }
}

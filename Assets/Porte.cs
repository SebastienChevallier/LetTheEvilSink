using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    public Transform tpTransform;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(player)
            {
                Debug.Log("E");
                player.transform.position = new Vector3(tpTransform.position.x, player.transform.position.y, tpTransform.position.z);
            }
        }
            
        
    }

}

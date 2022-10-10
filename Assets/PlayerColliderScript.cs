using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderScript : MonoBehaviour
{
    private Player_Movements _Player;

    private void Start()
    {
        _Player = transform.parent.GetComponent<Player_Movements>();
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}

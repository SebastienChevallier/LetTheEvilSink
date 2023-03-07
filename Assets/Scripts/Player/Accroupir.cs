using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accroupir : MonoBehaviour
{
    public So_Player _playerData;
    private Vector3 playerTransform;
    public GameObject lampeTorche;
    

    // Update is called once per frame
    void Update()
    {
        if (_playerData._CanMove)
        {
            if (Input.GetButtonDown("Accroupir"))
            {
                playerTransform = transform.position;
                lampeTorche.SetActive(false);
                _playerData._CanLight = false;
            }

            if (Input.GetButton("Accroupir"))
            {
                _playerData._Hiding = true;
                _playerData._CanInteract = false;
                _playerData._CanMove = false;
                _playerData._InDark = true;
                transform.position = playerTransform - new Vector3(0,1,0);
                lampeTorche.SetActive(false);
            }       

            if (Input.GetButtonUp("Accroupir"))
            {
                _playerData._CanLight = true;
                _playerData._CanMove = true;
                _playerData._Hiding = false;
                _playerData._CanInteract = true;
                transform.position = playerTransform;
            }
        }
        


    }
}

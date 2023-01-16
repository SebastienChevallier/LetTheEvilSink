using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portes : MonoBehaviour
{
    public GameObject player;

    public GameObject trigger;
    public GameObject trigger2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player)
            {
                if (trigger.activeSelf)
                {
                    player.transform.position = new Vector3(trigger2.transform.position.x, player.transform.position.y, trigger2.transform.position.z);
                    trigger2.SetActive(true);
                    trigger.SetActive(false);

                }
                else
                {
                    player.transform.position = new Vector3(trigger.transform.position.x, player.transform.position.y, trigger.transform.position.z);
                    trigger.SetActive(true);
                    trigger2.SetActive(false);

                }    
            }
        }
    }
}

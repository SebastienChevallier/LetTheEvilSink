using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portes : MonoBehaviour
{
    public GameObject player;

    public GameObject trigger;
    public GameObject trigger2;

    public bool frontTriggered = false;
    public bool backTriggered = false;

    public bool allow_Y_Tp;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player)
            {
                if (frontTriggered)
                {
                    Debug.Log("En Haut");
                    if (allow_Y_Tp)
                    {
                        player.transform.position = new Vector3(trigger2.transform.position.x, trigger2.transform.position.y+1, trigger2.transform.position.z);
                        
                    }
                    else
                    {
                        player.transform.position = new Vector3(trigger2.transform.position.x, player.transform.position.y, trigger2.transform.position.z);
                    }

                    //trigger2.SetActive(true);
                    //trigger.SetActive(false);

                }
                else if (backTriggered)
                {
                    Debug.Log("En Bas");
                    if (allow_Y_Tp)
                    {
                        player.transform.position = new Vector3(trigger.transform.position.x, trigger.transform.position.y + 1, trigger.transform.position.z);
                    }
                    else
                    {
                        player.transform.position = new Vector3(trigger.transform.position.x, player.transform.position.y, trigger.transform.position.z);
                    }
                    //trigger.SetActive(true);
                    //trigger2.SetActive(false);

                }    
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portes : MonoBehaviour
{
    public GameObject player;

    public GameObject trigger;
    public GameObject trigger2;

    public bool frontTriggered = false;
    public bool backTriggered = false;

    public bool allow_Y_Tp;
    public Image panelFade;
    public float fadeValue = 0f;
    
    public float fadeSpeed = 2f;

    private void Start()
    {
        panelFade = GameObject.Find("Fade-In-Out").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Fade();
        if (Input.GetKeyDown(KeyCode.E))
        {
           
            if (player)
            {
                StartCoroutine(DelayFade(fadeSpeed));
                fadeValue = 1f;
                if (frontTriggered)
                {
                    Debug.Log("En Haut");
                    if (allow_Y_Tp)
                    {
                        player.transform.position = new Vector3(trigger2.transform.position.x, trigger2.transform.position.y+1, trigger2.transform.position.z);
                        player.transform.rotation = trigger2.transform.rotation;
                        
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
                        player.transform.rotation = trigger.transform.rotation;
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
    
    IEnumerator DelayFade(float time)
    {
        yield return new WaitForSeconds(time);
        fadeValue = 0;
    }

    public float speedVal;
    void Fade()
    {
        if(panelFade != null)
        {
            Vector4 color = new Vector4(panelFade.color.r, panelFade.color.g, panelFade.color.b, fadeValue);
            panelFade.color = Vector4.Lerp(panelFade.color, color, Time.deltaTime * speedVal);
        }
    }
}

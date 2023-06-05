using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Portes : MonoBehaviour
{
    public GameObject player;
    public So_Player _PlayerData;

    public GameObject trigger;
    public GameObject trigger2;

    public bool frontTriggered = false;
    public bool backTriggered = false;

    
    public bool allow_Y_Tp;
    public Image panelFade;
    public float fadeValue = 0f;
    
    public float fadeSpeed = 2f;

    public float speedVal;


    private void Start()
    {
        panelFade = GameObject.Find("Fade-In-Out").GetComponent<Image>();
        fadeValue = 0f;
    }

    void Update()
    {
        if (player) Fade();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player)
            {
                fadeValue = 1f;

                StartCoroutine(DelayTp(fadeSpeed));
                StartCoroutine(DelayFade(fadeSpeed));
            }
        }
    }
    
    IEnumerator DelayFade(float time)
    {
        FadeManager.Instance.FadeIn();
        yield return new WaitForSeconds(time);
        
        fadeValue = 0;

        _PlayerData._CanMove = true;
    }

    IEnumerator DelayTp(float time)
    {
        _PlayerData._CanMove = false;

        yield return new WaitForSeconds(time/2);
        FadeManager.Instance.FadeOut();

        if (frontTriggered)
        {
            if (allow_Y_Tp)
            {
                player.transform.position = new Vector3(trigger2.transform.position.x, trigger2.transform.position.y+1, trigger2.transform.position.z);
                player.transform.rotation = trigger2.transform.rotation;
            }
            else
            {
                player.transform.position = new Vector3(trigger2.transform.position.x, player.transform.position.y, trigger2.transform.position.z);
            }
        }
        else if (backTriggered)
        {
                    
            if (allow_Y_Tp)
            {
                player.transform.position = new Vector3(trigger.transform.position.x, trigger.transform.position.y + 1, trigger.transform.position.z);
                player.transform.rotation = trigger.transform.rotation;
            }
            else
            {
                player.transform.position = new Vector3(trigger.transform.position.x, player.transform.position.y, trigger.transform.position.z);
            }
        }
    }
    
    void Fade()
    {
        if(panelFade != null)
        {
            Vector4 color = new Vector4(panelFade.color.r, panelFade.color.g, panelFade.color.b, fadeValue);
            panelFade.color = Vector4.Lerp(panelFade.color, color, Time.deltaTime * speedVal);
        }
    }
}

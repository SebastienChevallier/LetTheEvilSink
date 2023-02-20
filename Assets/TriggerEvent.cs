using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerEvent : MonoBehaviour
{
    public eventType _event;
    public So_Discution _Discution;
    public So_Player _Player;
    public string animName;
    public bool isTriggered;
    public GameObject texteNarrateur;
    
    public int _NumDial = 0;

    public float delay = 0.1f;
    public float delaySuiteDial = 0.1f;
    private float timer;
    public enum eventType
    {
        discution,
        animation
    }
    
    private Animator animator;
    
    private void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_Player._CanInteract && other.CompareTag("Player"))
        {
            if (isTriggered && animName != "")
            {
                switch (_event)
                {
                    case eventType.discution:
                        texteNarrateur.SetActive(true);
                        StartCoroutine(ShowText(_Discution._Dialog[_NumDial]._Discution, texteNarrateur));
                        break;
                    
                    case eventType.animation:
                        animator.SetTrigger(animName);
                        break;
                    
                    default:
                        break;
                }
                isTriggered = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private string currentText;
    IEnumerator ShowText(string texte, GameObject obj)
    {
        for(int i = 0; i <= texte.Length; i++)
        {
            currentText = texte.Substring(0, i);
            obj.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        
    }
}

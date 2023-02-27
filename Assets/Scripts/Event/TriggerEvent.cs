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
    public float delaySuiteDial = 1f;
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
        if (other.CompareTag("Player"))
        {
            if (!isTriggered)
            {
                switch (_event)
                {
                    case eventType.discution:
                        texteNarrateur.SetActive(true);
                        _Player._CanInteract = false;
                        isTriggered = true;
                        break;
                    
                    case eventType.animation:
                        if (animName != "")
                        {
                            animator.SetTrigger(animName);
                            _Player._CanMove = false;
                            _Player._CanInteract = false;
                            isTriggered = true;
                        }
                        break;
                    
                    default:
                        break;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            timer += Time.deltaTime;
            if (timer > delaySuiteDial)
            {
                Debug.Log("In");
                StartCoroutine(ShowText(_Discution._Dialog[_NumDial]._Discution, texteNarrateur.transform.GetChild(0).gameObject));
                _NumDial++;
                timer = 0;
            }
            
            if(_NumDial > _Discution._Dialog.Length)
            {
                _Player._CanMove = true;
                _Player._CanInteract = true;
                texteNarrateur.SetActive(false);
                _NumDial = 0;
            }
        }
    }

    private string currentText;
    IEnumerator ShowText(string texte, GameObject obj)
    {
        for(int i = 0; i <= texte.Length; i++)
        {
            currentText = texte.Substring(0, i);
            obj.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
            
            if (Input.GetButtonDown("Interact") && _NumDial > 0)
            {
                i = texte.Length;
            }
        }
    }
}

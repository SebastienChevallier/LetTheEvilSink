using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    
    [Header("---Basic---")]
    public So_Discution _Dis;
    public bool canBeTrigger = true;
    private bool playingOnce = false;

    public bool autoDialog = false;
    public bool open = false;
    
    public bool pnjDespawn;

    private DialogueManager _DialogueManager;
    [HideInInspector]public bool isTrigger = false;
    
    [Header("---Suite dialogue---")]
    public bool newDialogue = false;
    [SerializeField] private List<DialogueTrigger> _ListDialogue;

    [Header("---Objectif---")]
    public bool newObjectif = false;
    public string objectif;
    
    private void Start()
    {
        _DialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue ()
    {
        _DialogueManager.StartDialogue(_Dis);
    }
    
    
    void Update()
    {        
        if (_DialogueManager.sentences.Count == 0 && isTrigger && open && !playingOnce)
        {
            if(newObjectif) RappelObjectif.Instance.Rappel(objectif);
            _DialogueManager.EndDialogue();
            
            open = false;
            if (_ListDialogue != null)
            {
                foreach (DialogueTrigger dialogue in _ListDialogue)
                {
                    dialogue.canBeTrigger = true;
                    canBeTrigger = false;
                    playingOnce = true;
                }
            }

            if (pnjDespawn)
            {
                gameObject.SetActive(false);
            }
        }
        if (Input.GetButtonDown("Interact")  && _DialogueManager.sentences.Count == 0 && isTrigger && !open && !playingOnce && canBeTrigger && !autoDialog)
        {
            TriggerDialogue();
            open = true;
        }
        else if((Input.GetButtonDown("Interact") || Input.GetButtonDown("LampeTorche")) && _DialogueManager.sentences.Count != 0 && isTrigger && open && !playingOnce && canBeTrigger)
        {
            if (_DialogueManager.passSentence)
            {
                _DialogueManager.DisplayNextSentence();
                _DialogueManager.passSentence = false;
            }
            else
            {
                _DialogueManager.ClickNext();
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;

            if (autoDialog)
            {
                TriggerDialogue();
                open = true;
                Player_Movements.Instance.rb.velocity = Vector3.zero;
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = false;
        }
    }

}

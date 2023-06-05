using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    
    public So_Discution _Dis;
    public bool canBeTrigger = true;
    private bool playingOnce = false;

    private DialogueManager _DialogueManager;
    [HideInInspector]public bool isTrigger = false;
    
    [SerializeField] private List<DialogueTrigger> _ListDialogue;

    public bool open = false;

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
        }
        if (Input.GetButtonDown("Interact") && _DialogueManager.sentences.Count == 0 && isTrigger && !open && !playingOnce && canBeTrigger)
        {
            TriggerDialogue();
            open = true;
        }
        else if(Input.GetButtonDown("Interact") && _DialogueManager.sentences.Count != 0 && isTrigger && open && !playingOnce && canBeTrigger)
        {
            _DialogueManager.DisplayNextSentence();
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;
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

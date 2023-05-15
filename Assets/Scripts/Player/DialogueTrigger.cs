using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    
    public So_Discution _Dis;

    private DialogueManager _DialogueManager;
    
    
    public bool open = false;

    private void Start()
    {
        _DialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue ()
    {
        _DialogueManager.StartDialogue(_Dis);
    }
    
    public bool isTrigger = false;
    void Update()
    {        
        if (_DialogueManager.sentences.Count == 0 && isTrigger)
        {
            _DialogueManager.EndDialogue();
            open = false;
        }
        if (Input.GetButtonDown("Interact") && _DialogueManager.sentences.Count == 0 && isTrigger && !open)
        {
            TriggerDialogue();
            open = true;
        }
        else if(Input.GetButtonDown("Interact") && _DialogueManager.sentences.Count != 0 && isTrigger && open)
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

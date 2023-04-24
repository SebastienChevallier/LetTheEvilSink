using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Queue<string> sentences;
    private Queue<string> names;
    
    
    [Header("UI")]
    public GameObject _PanelParler;

    [Header("PlayerData")]
    public So_Player _PlayerData;

    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue (So_Discution dialogue)
    {
        if (_PlayerData._CanInteract || _PlayerData._CanTalk)
        {
            _PlayerData._CanInteract = false;
            _PlayerData._CanTalk = true;
            _PlayerData._CanMove = false;
            _PanelParler.SetActive(true);
        }

        foreach (So_Discution._Discutions sentence in dialogue._Dialog)
        {
            sentences.Enqueue(sentence._Discution);
            names.Enqueue(sentence._NomPerso);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        nameText.text = names.Dequeue();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        _PanelParler.SetActive(false);
        _PlayerData._CanMove = true;
        _PlayerData._CanInteract = true;
        _PlayerData._CanTalk = false;
    }

}
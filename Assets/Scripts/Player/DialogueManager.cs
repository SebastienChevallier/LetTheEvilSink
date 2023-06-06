using System.Collections;
using System.Collections.Generic;
using BaseTemplate.Behaviours;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoSingleton<DialogueManager> {

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image _ImagePerso1;
    public Image _ImagePerso2;

    public Queue<string> sentences;
    private Queue<string> names;
    private Queue<bool> bools;
    private Queue<Sprite> sprites;
    
    
    [Header("UI")]
    public GameObject _PanelParler;

    [Header("PlayerData")]
    public So_Player _PlayerData;

    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();
        names = new Queue<string>();
        bools = new Queue<bool>();
        sprites = new Queue<Sprite>();
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
            bools.Enqueue(sentence._PlayerIsSpeaking);
            sprites.Enqueue(sentence._SpritePerso);
        }

        DisplayNextSentence();
    }

    public bool passSentence = false;
    
    public void DisplayNextSentence ()
    {
        passSentence = false;
        nameText.text = names.Dequeue();
        bool isPlayer = bools.Dequeue();
        string sentence = sentences.Dequeue();
        Sprite sprite = sprites.Dequeue();

        if (isPlayer)
        {
            nameText.text = "";
            _ImagePerso1.sprite = sprite;
        }
        else
        {
            _ImagePerso2.sprite = sprite;
        }
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (passSentence)
            {
                dialogueText.text = sentence;
                yield break;
            }
            else
            {
                dialogueText.text += letter;
            }
            yield return null;
        }
    }
    
    public void ClickNext()
    {
        passSentence = true;
    }

    public void EndDialogue()
    {
        _PanelParler.SetActive(false);
        _PlayerData._CanMove = true;
        _PlayerData._CanInteract = true;
        _PlayerData._CanTalk = false;
    }
}
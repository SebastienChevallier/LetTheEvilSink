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
    public Image bgTexte;

    public Queue<string> sentences;
    private Queue<string> names;
    private Queue<bool> bools;
    private Queue<Sprite> sprites;
    private Queue<TMP_FontAsset> fonts;
    private TMP_FontAsset defaultFont;
    
    
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
        fonts = new Queue<TMP_FontAsset>();
    }

    public void StartDialogue (So_Discution dialogue)
    {
        if (_PlayerData._CanInteract || _PlayerData._CanTalk)
        {
            _PlayerData._CanInteract = false;
            _PlayerData._CanTalk = true;
            _PlayerData._CanMove = false;
            _PanelParler.SetActive(true);
            if(Player_Movements.Instance)
                Player_Movements.Instance.planeAnimator.SetFloat("Speed", 0);
        }

        foreach (So_Discution._Discutions sentence in dialogue._Dialog)
        {
            sentences.Enqueue(sentence._Discution);
            names.Enqueue(sentence._NomPerso);
            bools.Enqueue(sentence._PlayerIsSpeaking);
            sprites.Enqueue(sentence._SpritePerso);
            fonts.Enqueue(sentence.font);
        }

        defaultFont = dialogue.defaultFont;
        
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
        TMP_FontAsset font = fonts.Dequeue();

        if (isPlayer) { _ImagePerso1.transform.localScale = new Vector3(3f,3,3); }
        else { _ImagePerso1.transform.localScale = new Vector3(-3f,3,3); }
        
        _ImagePerso1.sprite = sprite;
        if (font != null)
            dialogueText.font = font;
        else
            dialogueText.font = defaultFont;

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
                
                if (dialogueText.text.Length == sentence.Length)
                {
                    ClickNext();
                }
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
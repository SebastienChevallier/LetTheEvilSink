using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Personnage : MonoBehaviour
{
    public So_Discution _Dis;
    
    
    [Header("UI")]
    public GameObject _PanelParler;

    [Header("PlayerData")]
    public So_Player _PlayerData;

    private int _NumDial = 0;
    private string currentText;
    
    [Header("Delay")]
    public float delay = 0.01f;
    public float timerInput;
    private float delayInput = 3f;
    
    private void DelayInput()
    {
        if(Input.GetButtonDown("Interact"))
        {
            if (timerInput <= 0)
            {
                timerInput = delayInput;
            }
        }

        if (timerInput >= 0)
        {
            timerInput -= Time.deltaTime;
        }
    }

    public bool isTrigger = false;
    void Update()
    {
        
        if(Input.GetButtonDown("Interact") && timerInput <= 0)
        {
            Debug.Log("E");
            if(isTrigger)
            {
                Debug.Log("isTrigger");
                Parler(); 
            }
        }
        DelayInput();
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

    public void Parler()
    {
        if (_PlayerData._CanInteract || _PlayerData._CanTalk)
        {
            Debug.Log(_NumDial);
            Debug.Log(_Dis._Dialog.Length);
            _PlayerData._CanInteract = false;
            _PlayerData._CanTalk = true;
            _PlayerData._CanMove = false;
            _PanelParler.SetActive(true);

            if (_NumDial < _Dis._Dialog.Length)
            {
                _NumDial++;

                if (_Dis._Dialog[_NumDial - 1]._PlayerIsSpeaking && timerInput <= 0)
                {
                    _PanelParler.transform.GetChild(2).gameObject.SetActive(true);
                    _PanelParler.transform.GetChild(3).gameObject.SetActive(false);

                    _PanelParler.transform.GetChild(2).GetComponent<Image>().sprite = _Dis._Dialog[_NumDial - 1]._SpritePerso;
                    _PanelParler.transform.GetChild(0).GetComponent<Image>().sprite = _Dis._Perso1;
                    _PanelParler.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = _Dis._Dialog[_NumDial - 1]._NomPerso;

                    

                    _PanelParler.transform.GetChild(3).GetComponent<Image>().sprite = _Dis._Dialog[_NumDial - 1]._SpritePerso;
                    _PanelParler.transform.GetChild(1).GetComponent<Image>().sprite = _Dis._Perso2;
                    _PanelParler.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                }
                else
                {
                    _PanelParler.transform.GetChild(2).gameObject.SetActive(false);
                    _PanelParler.transform.GetChild(3).gameObject.SetActive(true);

                    _PanelParler.transform.GetChild(2).GetComponent<Image>().sprite = _Dis._Dialog[_NumDial - 1]._SpritePerso;
                    _PanelParler.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";

                    _PanelParler.transform.GetChild(3).GetComponent<Image>().sprite = _Dis._Dialog[_NumDial - 1]._SpritePerso;
                    _PanelParler.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = _Dis._Dialog[_NumDial - 1]._NomPerso;
                }

                //_PanelParler.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = _PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Dialog[_NumDial - 1]._Discution;
                StartCoroutine(ShowText(_Dis._Dialog[_NumDial - 1]._Discution, _PanelParler.transform.GetChild(4).GetChild(0).gameObject));
            }
            else
            {
                _NumDial = 0;
                _PanelParler.SetActive(false);
                _PlayerData._CanMove = true;
                _PlayerData._CanInteract = true;
                _PlayerData._CanTalk = false;
            }   
        }
    }
    
    IEnumerator ShowText(string texte, GameObject obj)
    {
        for(int i = 0; i <= texte.Length; i++)
        {
            currentText = texte.Substring(0, i);
            obj.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
            
            if(texte.Length == i)
            {
                timerInput = 0;
            }
            
            if (Input.GetButtonDown("Interact") && _NumDial > 0)
            {
                i = texte.Length;
                
            }
        }
    }
}

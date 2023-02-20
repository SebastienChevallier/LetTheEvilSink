using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Interact : MonoBehaviour
{

    [Header("UI")]
    public GameObject _PanelObserver;
    public GameObject _PanelParler;
    public GameObject _PanelCarnet;

    [Header("PlayerData")]
    public So_Player _PlayerData;

    private int _NumDial = 0;
    public GameObject _Visuals;

    [Header("UI")]
    public float delay = 0.1f;

    private string currentText;

    // Update is called once per frame
    void Update()
    {
        Interagir();
    }

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

    public void Interagir()
    {
        if (_PlayerData._TriggerObject != null)
        {
            if (Input.GetButtonDown("Interact"))
            {
                switch (_PlayerData._TriggerObject.tag)
                {
                    case "Observer":
                        if (_PlayerData._CanInteract)
                        {
                            _PlayerData._CanInteract = false;
                            _PanelObserver.SetActive(true);
                            _PanelObserver.transform.GetChild(0).GetComponent<Image>().sprite = _PlayerData._TriggerObject.GetComponent<Objets>().infoObjet.image;
                            _PanelObserver.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _PlayerData._TriggerObject.GetComponent<Objets>().infoObjet.texte;
                        }
                        else
                        {
                            _PlayerData._CanInteract = true;
                            _PanelObserver.SetActive(false);
                        }
                        break;

                    case "Deplacer":
                        if (_PlayerData._CanInteract)
                        {
                            if (!_PlayerData._TriggerObject.GetComponent<Animator>().GetBool("Interact"))
                            {
                                _PlayerData._TriggerObject.GetComponent<Animator>().SetBool("Interact", true);
                            }
                            else
                            {
                                _PlayerData._TriggerObject.GetComponent<Animator>().SetBool("Interact", false);
                            }
                                
                        }                     
                        break;

                    case "Cables":
                        //SceneManager.LoadSceneAsync("Cables", LoadSceneMode.Additive);

                        break;

                    case "Recuperer":
                        //Recuperation de loot                        
                        break;

                    case "Parler":
                        if (_PlayerData._CanInteract || _PlayerData._CanTalk)
                        {
                            Debug.Log(_NumDial);
                            _PlayerData._CanInteract = false;
                            _PlayerData._CanTalk = true;
                            _PlayerData._CanMove = false;
                            _PanelParler.SetActive(true);

                            if (_NumDial < _PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Dialog.Length)
                            {
                                _NumDial++;

                                if (_PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Dialog[_NumDial - 1]._PlayerIsSpeaking)
                                {
                                    _PanelParler.transform.GetChild(2).gameObject.SetActive(true);
                                    _PanelParler.transform.GetChild(3).gameObject.SetActive(false);

                                    _PanelParler.transform.GetChild(2).GetComponent<Image>().sprite = _PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Dialog[_NumDial - 1]._SpritePerso;
                                    _PanelParler.transform.GetChild(0).GetComponent<Image>().sprite = _PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Perso1;
                                    _PanelParler.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = _PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Dialog[_NumDial - 1]._NomPerso;

                                    

                                    _PanelParler.transform.GetChild(3).GetComponent<Image>().sprite = _PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Dialog[_NumDial - 1]._SpritePerso;
                                    _PanelParler.transform.GetChild(1).GetComponent<Image>().sprite = _PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Perso2;
                                    _PanelParler.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                                }
                                else
                                {
                                    _PanelParler.transform.GetChild(2).gameObject.SetActive(false);
                                    _PanelParler.transform.GetChild(3).gameObject.SetActive(true);

                                    _PanelParler.transform.GetChild(2).GetComponent<Image>().sprite = _PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Dialog[_NumDial - 1]._SpritePerso;
                                    _PanelParler.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";

                                    _PanelParler.transform.GetChild(3).GetComponent<Image>().sprite = _PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Dialog[_NumDial - 1]._SpritePerso;
                                    _PanelParler.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = _PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Dialog[_NumDial - 1]._NomPerso;
                                }

                                //_PanelParler.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = _PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Dialog[_NumDial - 1]._Discution;
                                StartCoroutine(ShowText(_PlayerData._TriggerObject.GetComponent<Personnage>()._Dis._Dialog[_NumDial - 1]._Discution, _PanelParler.transform.GetChild(4).GetChild(0).gameObject));
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
                        break;

                    case "Cacher":
                        if (!_PlayerData._Hiding)
                        {
                            _PlayerData._Hiding = true;
                            _PlayerData._CanInteract = false;
                            _PlayerData._CanMove = false;
                            _PlayerData._InDark = true;
                            _Visuals.SetActive(false);
                        }
                        else
                        {
                            _PlayerData._InDark = true;
                            _PlayerData._CanMove = true;
                            _PlayerData._Hiding = false;
                            _PlayerData._CanInteract = true;

                            _Visuals.SetActive(true);
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}

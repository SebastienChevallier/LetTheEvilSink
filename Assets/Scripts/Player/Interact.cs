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
    
    
    public CreatureStateManager creature;

    private void Start()
    {
        creature = GameObject.FindWithTag("Creature").GetComponent<CreatureStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Interagir();  
        Carnet();
    }
    
    public bool carnet = false;
    private void Carnet()
    {
        if (_PlayerData._CanInteract && Input.GetButtonDown("Carnet"))
        {
            if (carnet)
            {
                _PanelCarnet.SetActive(true);
            }
            else
            {
                _PanelCarnet.SetActive(false);
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
                            if(_PlayerData._TriggerObject.GetComponent<AddForceCollider>() != null)
                            {
                                _PlayerData._TriggerObject.GetComponent<AddForceCollider>().Impulse();
                                creature.AddGauge(20);
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
                            GetComponent<Player_Movements>()._LampeTorche.SetActive(false);
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

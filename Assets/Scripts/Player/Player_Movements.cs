using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Movements : MonoBehaviour
{
    [Header("PlayerData")]
    public So_Player _PlayerData;

    [Header("Player Variable")]
    public float _WalkSpeed;
    public float _RunSpeed;
    [SerializeField]
    private float _Speed;
    public AnimationCurve _SmoothCurve;
    public float _SmoothSpeed;
    public GameObject _LampeTorche;
    public GameObject _Visuals;

    private Transform _LastPosition;
    
    private bool _CanInteract;
    private bool _CanLight;
    private bool _CanMove = true;
    private bool _Hiding = false;

    public Camera _Camera;

    [Header("World Interactions")]
    public GameObject _TriggerObject;

    [Header("UI")]
    public GameObject _PanelObserver;
    public GameObject _PanelParler;
    public GameObject _PanelCarnet;    
    
    private Rigidbody rb;

    public void Start()
    {        
        rb = GetComponent<Rigidbody>();
        _CanInteract = true;
        _CanLight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Interagir();
        Course();
        Carnet();
        Movement();
        LampeTorche();
        Flip();
    }

    void Movement()
    {
        Vector3 moveDir = Input.GetAxis("Horizontal") * _Camera.gameObject.transform.right * _Speed;

        if (_CanMove)
        {
            rb.velocity = moveDir;
        }
        
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0f)
        {
            _Visuals.transform.localScale = new Vector3(1, 1, 1);
        }else if(Input.GetAxis("Horizontal") < 0f)
        {
            _Visuals.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Course()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Sprint"))
        {
            _Speed = _RunSpeed;
        }
        else
        {
            _Speed = _WalkSpeed;
        }
    }

    void Carnet()
    {
        if (Input.GetButtonDown("Carnet"))
        {
            if (_CanInteract)
            {                
                _CanInteract = false;
                _CanMove = false;
                _PanelCarnet.SetActive(true);
            }
            else
            {
                _CanMove = true;
                _CanInteract = true;
                _PanelCarnet.SetActive(false);
            }           
        }
    }

    public void Interagir()
    {
        if(_TriggerObject != null)
        {
            if (Input.GetButtonDown("Interact"))
            {
                switch (_TriggerObject.tag)
                {
                    case "Observer":                        
                        if (_CanInteract)
                        {
                            _CanInteract = false;
                            _PanelObserver.SetActive(true);
                            _PanelObserver.transform.GetChild(0).GetComponent<Image>().sprite = _TriggerObject.GetComponent<Objets>().infoObjet.image;
                            _PanelObserver.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _TriggerObject.GetComponent<Objets>().infoObjet.texte;
                        }
                        else
                        {
                            _CanInteract = true;
                            _PanelObserver.SetActive(false);
                        }                        
                        break;

                    case "Deplacer":                        
                        //Pouvoir deplacer des objets                        
                        break;

                    case "Recuperer":                        
                        //Recuperation de loot                        
                        break;

                    case "Parler":                        
                         //Parler au PNJ                        
                        break;

                    case "Cacher":                        
                        if (!_Hiding)
                        {
                            Debug.Log("Hide");

                            _Hiding = true;
                            _CanInteract = false;
                            _CanMove = false;
                            
                            _Visuals.SetActive(false);
                            
                        }
                        else
                        {
                            Debug.Log("Not hide");
                            _CanMove = true;
                            _Hiding = false;
                            _CanInteract = true;

                            _Visuals.SetActive(true);
                        }                        
                        break;

                    default:
                        break;
                }
            }
        }        
    }

    void LampeTorche()
    {
        if (Input.GetButtonDown("LampeTorche"))
        {
            if (_CanLight)
            {
                _CanLight = false;
                _LampeTorche.SetActive(true);
            }
            else
            {
                _CanLight = true;
                _LampeTorche.SetActive(false);
            }
        }
    }
}

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

    public Camera _Camera;    

    [Header("UI")]
    public GameObject _PanelObserver;
    public GameObject _PanelParler;
    public GameObject _PanelCarnet;    
    
    private Rigidbody rb;
    private float _Dir;

    public void Start()
    {        
        rb = GetComponent<Rigidbody>();
        _PlayerData._CanInteract = true;
        _PlayerData._CanLight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        Interagir();
        Course();
        Carnet();
              
        LampeTorche();
        Flip();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 moveDir = Input.GetAxis("Horizontal") * _Camera.gameObject.transform.right * _Speed;

        if (_PlayerData._CanMove)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, moveDir, _SmoothCurve.Evaluate(Time.fixedDeltaTime * _SmoothSpeed));
            
        }
        else
        {
            rb.velocity = Vector3.zero;
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
            if (_PlayerData._CanInteract)
            {
                _PlayerData._CanInteract = false;
                _PlayerData._CanMove = false;
                _PanelCarnet.SetActive(true);
            }
            else
            {
                _PlayerData._CanMove = true;
                _PlayerData._CanInteract = true;
                _PanelCarnet.SetActive(false);
            }           
        }
    }

    public void Interagir()
    {
        if(_PlayerData._TriggerObject != null)
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
                        //Pouvoir deplacer des objets                        
                        break;

                    case "Recuperer":                        
                        //Recuperation de loot                        
                        break;

                    case "Parler":                        
                         //Parler au PNJ                        
                        break;

                    case "Cacher":                        
                        if (!_PlayerData._Hiding)
                        {
                            Debug.Log("Hide");

                            _PlayerData._Hiding = true;
                            _PlayerData._CanInteract = false;
                            _PlayerData._CanMove = false;
                            
                            _Visuals.SetActive(false);
                            
                        }
                        else
                        {
                            Debug.Log("Not hide");
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

    void LampeTorche()
    {
        if (Input.GetButtonDown("LampeTorche"))
        {
            if (_PlayerData._CanLight)
            {
                _PlayerData._CanLight = false;
                _LampeTorche.SetActive(true);
            }
            else
            {
                _PlayerData._CanLight = true;
                _LampeTorche.SetActive(false);
            }
        }
    }
}

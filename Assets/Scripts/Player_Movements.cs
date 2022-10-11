using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Movements : MonoBehaviour
{
    [Header("Player Variable")]
    public float _WalkSpeed;
    public float _RunSpeed;
    [SerializeField]
    private float _Speed;

    
    private bool _CanInteract;
    [Header("World Interactions")]
    public GameObject _TriggerObject;

    [Header("UI")]
    public GameObject _PanelObserver;
    public GameObject _PanelParler;
    

    
    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        _CanInteract = true;        
    }

    // Update is called once per frame
    void Update()
    {
        Interagir();
        Course();
        rb.velocity = Input.GetAxis("Horizontal") * -Vector3.right * _Speed * Time.deltaTime;
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
        if (Input.GetButtonDown("Interact"))
        {
            if (_CanInteract)
            {
                _CanInteract = false;
                
            }
            else
            {
                _CanInteract = true;
                
            }

           
        }
    }

    public void Interagir()
    {
        if(_TriggerObject != null)
        {
            switch (_TriggerObject.tag)
            {
                case "Observer":
                    if (Input.GetButtonDown("Interact"))
                    {
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

                        Debug.Log("Ouvre une image associée");
                        //Faire action
                        Debug.Log(_TriggerObject.GetComponent<Objets>().infoObjet.texte);
                    }
                    break;

                case "Deplacer":
                    if (Input.GetButton("Interact"))
                    {
                        //Pouvoir deplacer des objets
                    }
                    break;

                case "Recuperer":
                    if (Input.GetButtonDown("Interact"))
                    {
                        //Recuperation de loot
                    }
                    break;

                case "Parler":
                    if (Input.GetButtonDown("Interact"))
                    {
                        //Parler au PNJ
                    }
                    break;

                default:
                    break;
            }
           
        }
        
    }
}

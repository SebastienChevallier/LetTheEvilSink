using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Movements : MonoBehaviour
{
    [Header("PlayerData")]
    public CreatureStateManager _creature;
    public So_Player _PlayerData;
    
    public  float _Speed;
    public float inputSpeed = 1f;
    public AnimationCurve _SmoothCurve;
    public float _SmoothSpeed;

    private StepSound _StepSound;

    [Header("UI")]    
    public GameObject _PanelCarnet;
    public GameObject _LampeTorche;
    public GameObject _Visuals;
    public Camera _Camera;
    private Rigidbody rb;

    private Vector3 velocity = Vector3.zero;

    public void Start()
    {        
        rb = GetComponent<Rigidbody>();
        _StepSound = GetComponent<StepSound>();
        _PlayerData._CanInteract = true;
        InitPlayer();

        _creature = FindObjectOfType<CreatureStateManager>();
    }

    public void InitPlayer()
    {
        //initiate player scriptable object values
        _PlayerData._ValAngoisse = 0f;
        _PlayerData._CanInteract = true;
        _PlayerData._CanLight = false;
        _PlayerData._CanMove = true;
        _PlayerData._InDark = false;
        _PlayerData._CibleCamera = transform.gameObject;
    }

    void Update()
    {  
        Course();
        Carnet();              
        //LampeTorche();
        Flip();
        SonDePas(1f);
    }
        

    
    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 moveDir = _Camera.gameObject.transform.right * (Input.GetAxis("Horizontal") * _Speed);
        //moveDir += Input.GetAxis("Vertical") * _Camera.gameObject.transform.forward * _Speed;

        if (_PlayerData._CanMove)
        {
            //rb.velocity = Vector3.Lerp(rb.velocity, moveDir, _SmoothCurve.Evaluate(Time.fixedDeltaTime * _SmoothSpeed));
            rb.velocity = Vector3.SmoothDamp(rb.velocity, moveDir, ref velocity, inputSpeed);
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
        }
        else if (Input.GetAxis("Horizontal") < 0f)
        {
            _Visuals.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Course()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Sprint"))
        {
            _Speed = _PlayerData._RunSpeed;
        }
        else
        {
            _Speed = _PlayerData._WalkSpeed;
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

    void LampeTorche()
    {
        if (Input.GetButtonDown("LampeTorche") && _PlayerData._CanMove)
        {
            if (_PlayerData._CanLight)
            {
                _PlayerData._InDark = false;
                _PlayerData._CanLight = false;
                _LampeTorche.SetActive(true);
                _creature.AddGauge(5);
            }
            else
            {
                _PlayerData._InDark = true;
                _PlayerData._CanLight = true;
                _LampeTorche.SetActive(false);
            }
        }
    }

    void SonDePas(float duration)
    {
        if (rb.velocity.x >= 1f || rb.velocity.x <= -1f)
        {
            _StepSound.Step(duration);
            
        }
            
        else if ((rb.velocity.x >= 0.5f && rb.velocity.x <= 1f) || (rb.velocity.x <= -0.5f && rb.velocity.x >= -1f))
        {
            _StepSound.Step(duration / 2);
            
        }
        else if ((rb.velocity.x <= 0.5f && rb.velocity.x > 0) || (rb.velocity.x >= -0.5f && rb.velocity.x < 0))
        {
            _StepSound.Step(duration / 4);
        }
            
    }
}

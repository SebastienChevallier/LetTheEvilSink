using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Movements : MonoBehaviour
{
    [Header("PlayerData")]
    public So_Player _PlayerData;
    
    private float _Speed;
    public AnimationCurve _SmoothCurve;
    public float _SmoothSpeed;

    [Header("UI")]
    
    public GameObject _PanelCarnet;

    public GameObject _LampeTorche;
    public GameObject _Visuals;

    public Camera _Camera;
    private Rigidbody rb;
    

    public void Start()
    {        
        rb = GetComponent<Rigidbody>();
        _PlayerData._CanInteract = true;
        //_PlayerData._CanLight = true;
    }

    // Update is called once per frame
    void Update()
    {  
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
        if (Input.GetButtonDown("LampeTorche"))
        {
            if (_PlayerData._CanLight)
            {
                _PlayerData._InDark = false;
                _PlayerData._CanLight = false;
                _LampeTorche.SetActive(true);
            }
            else
            {
                _PlayerData._InDark = true;
                _PlayerData._CanLight = true;
                _LampeTorche.SetActive(false);
            }
        }
    }
}

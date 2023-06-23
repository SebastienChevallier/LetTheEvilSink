using System.Collections;
using System.Collections.Generic;
using BaseTemplate.Behaviours;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Movements : MonoSingleton<Player_Movements>
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
    public GameObject _PanelMort;
    public Camera _Camera;
    public Rigidbody rb;

    private Vector3 velocity = Vector3.zero;
    public Animator planeAnimator;

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
        if (!_PlayerData._CanMove) return;

        Course();
        Flip();
    }


    public void RespawnPlayer()
    {
        Debug.Log("Respawn:" + CheckPointsManager.Instance.lastCheckPoint.transform.position );
        StartCoroutine(Teleport());
        StartCoroutine(WaitTp());
    }

    IEnumerator Teleport()
    {
        _PlayerData._CanMove = false;
        FadeManager.Instance.ImageFadeIn();
        _PanelMort.SetActive(true);
        yield return new WaitForSeconds(2f);
        _PanelMort.SetActive(false);
        FadeManager.Instance.ImageFadeOut();
        _PlayerData._CanMove = true;
    }

    IEnumerator WaitTp()
    {
        yield return new WaitForSeconds(0.8f);
        transform.position = CheckPointsManager.Instance.lastCheckPoint.transform.position;
    }
    
    private void FixedUpdate()
    {
        if (!_PlayerData._CanMove) return;

        Movement();
    }

    void Movement()
    {
        Vector3 moveDir = _Camera.gameObject.transform.right * (Input.GetAxis("Horizontal") * _Speed);
        //moveDir += Input.GetAxis("Vertical") * _Camera.gameObject.transform.forward * _Speed;

        if (_PlayerData._CanMove)
        {
            planeAnimator.SetFloat("Speed", moveDir.magnitude / 2);
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

    

    public void SonDePas(float duration)
    {
        if (rb.velocity.x >= 1.5f || rb.velocity.x <= -1.5f)
        {
            _StepSound.Step(duration);
            Debug.Log("AddGauge");
            _creature.AddGauge(1);
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

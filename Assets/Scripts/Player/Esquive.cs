using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esquive : MonoBehaviour
{
    public So_Player _PlayerData;
    private Rigidbody rb;

    public float delay;
    public float timeLeft;

    private Animator _PlayerAnimator;

    public Vector3 dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && timeLeft < 0)
        {
            Dash();
            timeLeft = delay;
        }

        if(timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
        }
    }

    void Dash()
    {
        _PlayerAnimator.SetTrigger("Dash");
        dir = new Vector3(transform.GetChild(0).localScale.x,0,0);

        rb.AddForce(-dir * _PlayerData._DashDist, ForceMode.Impulse);
    }

    public void Invincible() 
    {
        _PlayerData._Invincible = true;
    }

    public void Vincible()
    {
        _PlayerData._Invincible = false;
    }
}

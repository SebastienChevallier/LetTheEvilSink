using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movements : MonoBehaviour
{
    public float _WalkSpeed;
    public float _RunSpeed;

    private bool _CanInteract;

    [SerializeField]
    private float _Speed;
    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Course();
        rb.velocity = Input.GetAxis("Horizontal") * -Vector3.right * _Speed * Time.deltaTime;
    }

    void Course()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _Speed = _RunSpeed;
        }
        else
        {
            _Speed = _WalkSpeed;
        }
    }

    void Interagir()
    {

    }
}

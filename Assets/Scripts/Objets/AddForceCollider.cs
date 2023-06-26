using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceCollider : MonoBehaviour
{
    public float force = 10f;
    public bool isTriggered = false;

    public Vector3 originPositon;
    public Quaternion originRotation;


    private void Start()
    {
        originPositon = transform.position;
        originRotation = transform.rotation;
    }

    public void Impulse()
    {
        if (isTriggered == false)
        {
            isTriggered = true;
            GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        }
        else
        {
            transform.position = originPositon;
            transform.rotation = originRotation;
            isTriggered = false;
        }
    }
}

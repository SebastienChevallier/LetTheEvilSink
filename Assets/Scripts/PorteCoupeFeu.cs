using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteCoupeFeu : MonoBehaviour
{
    public Animator animator;
    private bool isTriggered = false;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTriggered)
        {
            animator.SetBool("Porte_close", true);
            StartCoroutine(WaitForOpenDoor(5f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) isTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")) isTriggered = false;
    }

    IEnumerator WaitForOpenDoor(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("Porte_close", false);
    }
}

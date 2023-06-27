using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuseeTrigger : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(true);
            StartCoroutine(ReturnMenu());
        }
    }

    IEnumerator ReturnMenu()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }
}

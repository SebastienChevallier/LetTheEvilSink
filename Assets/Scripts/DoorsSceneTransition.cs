using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsSceneTransition : MonoBehaviour
{
    public int _ActualIntScene;
    public int _NextIntScene;


    private void OnTriggerStay(Collider other)
    {      
        if (Input.GetButtonDown("Interact") && other.CompareTag("Player"))
        {
            SceneManager.UnloadSceneAsync(_ActualIntScene);
            SceneManager.LoadScene(_NextIntScene, LoadSceneMode.Additive);
        }
    }
}

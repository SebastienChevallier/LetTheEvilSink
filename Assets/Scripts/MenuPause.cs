using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject panel;
    public So_Player _Player;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeSelf)
            {
                Resume();
            }
            else
            {
                panel.SetActive(true);
                Player_Movements.Instance.planeAnimator.SetFloat("Speed", 0);
                _Player._CanMove = false;
            }
        }
    }

    public void Resume()
    {
        panel.SetActive(false);
        if (!DialogueManager.Instance._PanelParler.activeSelf)
        {
            _Player._CanMove = true;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}

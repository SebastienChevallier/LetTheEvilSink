using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject panel;
    public So_Player _Player;
    public GameObject panelObjectif;
    
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
                panelObjectif.SetActive(false);
                Player_Movements.Instance.planeAnimator.SetFloat("Speed", 0);
                _Player._CanMove = false;
            }
        }
    }

    public void Resume()
    {
        panel.SetActive(false);
        panelObjectif.SetActive(true);

        if (!DialogueManager.Instance._PanelParler.activeSelf)
        {
            _Player._CanMove = true;
        }
    }

    public void LastCheckPoint()
    {
        Player_Movements.Instance.RespawnPlayer();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}

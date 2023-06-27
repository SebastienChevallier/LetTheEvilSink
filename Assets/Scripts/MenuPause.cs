using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuPause : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelObjectif;
    public So_Player _Player;

    public VideoPlayer _VideoPlayer;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeSelf)
            {
                if (_VideoPlayer.isPaused) _VideoPlayer.Play();

                Resume();
            }
            else
            {
                if (_VideoPlayer.isPlaying) _VideoPlayer.Pause();

                panel.SetActive(true);
                panelObjectif.SetActive(false);
                if (Player_Movements.Instance) Player_Movements.Instance.planeAnimator.SetFloat("Speed", 0);
                _Player._CanMove = false;
                _Player.inMenu = true;
            }
        }
    }

    public void Resume()
    {
        panel.SetActive(false);
        panelObjectif.SetActive(true);

        if (_VideoPlayer.isPaused) _VideoPlayer.Play();

        if (!DialogueManager.Instance._PanelParler.activeSelf)
        {
            _Player._CanMove = true;
        }

        _Player.inMenu = false;
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

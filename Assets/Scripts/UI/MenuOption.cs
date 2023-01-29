using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOption : MonoBehaviour
{
    public void Return()
    {
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}

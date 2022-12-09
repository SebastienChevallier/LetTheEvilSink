using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMiniJeux : MonoBehaviour
{
    public void Return()
    {
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void CardSwipe()
    {
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadScene("Card swipe", LoadSceneMode.Additive);
    }

    public void Crochetage()
    {
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadScene("Crochetagee", LoadSceneMode.Additive);
    }

    public void Cables()
    {
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadScene("Cables", LoadSceneMode.Additive);
    }
}

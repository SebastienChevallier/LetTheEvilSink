using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMiniJeux : MonoBehaviour
{
    public void Return()
    {
        SceneManager.UnloadSceneAsync("Mini jeux");
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void CardSwipe()
    {
        SceneManager.UnloadSceneAsync("Mini jeux");
        SceneManager.LoadScene("Carte", LoadSceneMode.Additive);
    }

    public void Crochetage()
    {
        SceneManager.UnloadSceneAsync("Mini jeux");
        SceneManager.LoadScene("Crochetage", LoadSceneMode.Additive);
    }

    public void Cables()
    {
        SceneManager.UnloadSceneAsync("Mini jeux");
        SceneManager.LoadScene("Cables", LoadSceneMode.Additive);
    }
}

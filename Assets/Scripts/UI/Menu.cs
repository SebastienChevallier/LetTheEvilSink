using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void Play()
    {
        StartCoroutine(LoadAsyncScene());
    }

    public void Option()
    {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadAsyncScene()
    {      
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}

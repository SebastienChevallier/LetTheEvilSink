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

    public void TrainingRoom()
    {
        StartCoroutine(LoadAsyncScene(3));
    }

    public void MiniJeux()
    {
        StartCoroutine(LoadAsyncScene("Mini Jeux"));
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

     IEnumerator LoadAsyncScene(int index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadAsyncScene(string name)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}

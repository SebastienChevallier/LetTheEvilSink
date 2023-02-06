using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public So_SceneToLoad sceneToLoad;

    public void LoadSceneTransition(int index, int lastScene)
    {
        sceneToLoad.index = index;
        sceneToLoad.SceneLoaderIndex = 3;
        sceneToLoad.LastSceneIndex = lastScene;
        SceneManager.LoadScene(sceneToLoad.SceneLoaderIndex, LoadSceneMode.Additive);
    }

    public void Play(int index)
    {
        LoadSceneTransition(index,1);
        //StartCoroutine(LoadAsyncScene());
    }

    public void TrainingRoom()
    {
        //StartCoroutine(LoadAsyncScene(3));
    }

    public void MiniJeux()
    {
        //StartCoroutine(LoadAsyncScene("Mini Jeux"));
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

    

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public So_SceneToLoad sceneToLoad;

    public Slider slider;

    private void Start()
    {
        SceneLoad(sceneToLoad.index);
    }

    void SceneLoad(int index)
    {
        StartCoroutine(LoadAsyncScene(index));
    }
    
    IEnumerator LoadAsyncScene(int index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(sceneToLoad.LastSceneIndex);
        SceneManager.UnloadSceneAsync(sceneToLoad.SceneLoaderIndex);

        while (!asyncLoad.isDone)
        {
            slider.value = asyncLoad.progress;
            yield return null;
        }
    }
}

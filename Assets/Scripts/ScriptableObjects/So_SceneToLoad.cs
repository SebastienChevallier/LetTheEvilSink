using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneToLoad", menuName = "ScriptableObjects/SceneToLoad", order = 1)]
public class So_SceneToLoad : ScriptableObject
{
    public int index;
    public int SceneLoaderIndex;
    public int LastSceneIndex;
}

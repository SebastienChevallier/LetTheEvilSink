using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsSceneTransition : MonoBehaviour
{
    public int _ActualIntScene;
    public int _NextIntScene;

    So_Creature so;
    CreatureStateManager creature;

    public int gaugeDiminution;


    private void Start()
    {
        so = Resources.Load<So_Creature>("Creature/So_Creature");
        creature = GameObject.FindWithTag("CreatureManager").GetComponent<CreatureStateManager>();
    }

    private void OnTriggerStay(Collider other)
    {      
        if (Input.GetButtonDown("Interact") && other.CompareTag("Player"))
        {
            so.AddGauge(gaugeDiminution);
            if (creature)
                creature.SwitchState(creature.WanderState);
            SceneManager.UnloadSceneAsync(_ActualIntScene);
            SceneManager.LoadScene(_NextIntScene, LoadSceneMode.Additive);
        }
    }
}

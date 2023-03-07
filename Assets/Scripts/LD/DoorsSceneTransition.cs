using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsSceneTransition : MonoBehaviour
{
    public int _ActualIntScene;
    public int _NextIntScene;

    CreatureStateManager creature;

    public int gaugeDiminution;


    private void Start()
    {
        creature = GameObject.FindWithTag("CreatureManager").GetComponent<CreatureStateManager>();
    }

    private void OnTriggerStay(Collider other)
    {      
        if (Input.GetButtonDown("Interact") && other.CompareTag("Player"))
        {
            creature.AddGauge(-gaugeDiminution);
            ResetStates();
            if (creature)
                creature.SwitchState(creature.WanderState);
            SceneManager.UnloadSceneAsync(_ActualIntScene);            
            SceneManager.LoadScene(_NextIntScene, LoadSceneMode.Additive);           
        }
    }

    void ResetStates()
    {
        creature.summoned = false;
        creature.playerDetected = false;
        creature.backFromChaseMode = false;
        creature.SearchState.soundHeard = false;
        creature.SearchState.positionChecked = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursePoursuite : MonoBehaviour
{
    public GameObject spawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        CreatureSpawnPoints.Instance.currentSpawnPoint = spawnpoint.transform;
        CreatureStateManager.Instance.gauge = 100;
        CreatureStateManager.Instance.SwitchState(CreatureStateManager.Instance.ChaseState);
    }
}

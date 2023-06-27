using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursePoursuite : MonoBehaviour
{
    public GameObject spawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        CreatureSpawnPoints.Instance.currentSpawnPoint = spawnpoint.transform;
        Debug.Log(CreatureSpawnPoints.Instance.currentSpawnPoint.transform.position);
        CreatureStateManager.Instance.gauge = 100;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursePoursuite : MonoBehaviour
{
    public GameObject spawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CreatureSpawnPoints.Instance.currentSpawnPoint = spawnpoint.transform;
            CreatureStateManager.Instance.gauge = 100;
            CreatureStateManager.Instance.visionDetectionInDark = 1000;
            CreatureStateManager.Instance.visionDetectionInLight = 1000;
        }
    }
}

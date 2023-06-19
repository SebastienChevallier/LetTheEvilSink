using UnityEngine;

public class SpawnBalconWall : MonoBehaviour
{
    public GameObject murInvisible;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) murInvisible.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) murInvisible.SetActive(false);
    }
}

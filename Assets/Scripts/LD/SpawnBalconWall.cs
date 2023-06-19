using UnityEngine;

public class SpawnBalconWall : MonoBehaviour
{
    public GameObject murInvisible;


    private void OnTriggerEnter(Collider other)
    {
        murInvisible.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        murInvisible.SetActive(false);
    }
}

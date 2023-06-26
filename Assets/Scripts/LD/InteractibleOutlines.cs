using UnityEngine;

public class InteractibleOutlines : MonoBehaviour
{
    public GameObject outline;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.SetActive(false);
        }
    }
}

using UnityEngine;

public class ObstaclesOutline : MonoBehaviour
{   
    public void OnTriggerEnter(Collider other)
    {
        transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
        transform.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 200f);
    }

    public void OnTriggerExit(Collider other)
    {
        transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.black);
        transform.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 20f);
    }
}

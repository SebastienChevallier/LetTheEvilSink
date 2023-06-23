using UnityEngine;

public class PlacardOutline : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
        GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 200f);
    }

    public void OnTriggerExit(Collider other)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.black);
        GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 20f);
    }
}

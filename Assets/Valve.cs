using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    private Vector3 mousePos;
    public GameObject valve;

    private void Start()
    {
        mousePos = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
        }
        

        Quaternion rotation = Quaternion.LookRotation(mousePos, Vector3.right);
        valve.transform.rotation = rotation;

        
    }
}

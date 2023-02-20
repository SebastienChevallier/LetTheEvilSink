using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomColider : MonoBehaviour
{
    public float zoomValue;
    public So_CameraParam _CameraParam;
    public float zoomSpeed;
    
    private float reff;

    private void OnTriggerExit(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
            _CameraParam._ZoomValue = Mathf.SmoothDamp(_CameraParam._ZoomValue, zoomValue, ref reff, zoomSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}

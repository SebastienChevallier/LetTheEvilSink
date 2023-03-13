using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOVEffect : MonoBehaviour
{
    public So_CameraParam _CameraParam;
    
    private Camera _Camera;
    
    private void Start()
    {
        _Camera = GetComponent<Camera>();
    }
    
    private void Update()
    {
        _Camera.fieldOfView = _CameraParam._FOV;
    }
}

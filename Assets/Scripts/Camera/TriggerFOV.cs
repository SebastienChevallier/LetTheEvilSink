using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFOV : MonoBehaviour
{
    public So_CameraParam _CameraParam;
    public float _FOV;

    // Update is called once per frame
    void Update()
    {
        _CameraParam._FOV = _FOV;
    }
}

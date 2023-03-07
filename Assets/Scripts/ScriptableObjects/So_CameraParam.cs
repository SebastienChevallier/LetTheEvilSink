using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraParam", menuName = "ScriptableObjects/CameraParam", order = 1)]
public class So_CameraParam : ScriptableObject
{
    [Header("Value")]
    public float _Speed;    
    public float _ZoomSpeed;

    [Range(2, 50)] public float _ZoomValue;
    public float _YOffset;

    public float _FOV;
}

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [Header("Data")]
    public So_Player _PlayerData;
    public Transform _Camera;
    public So_CameraParam _CameraParam;

    [Header("Value")]
    public float _Speed;    
    public float _ZoomSpeed;

    [Range(2, 50)] public float _ZoomValue;
    public float _YOffset;

    public float dampspeed;

  
    private Vector3 velocity = Vector3.zero;
    

    // Start is called before the first frame update
    void Start()
    {
        _Camera = transform.GetChild(0);
        _CameraParam._ZoomValue = _ZoomValue;
        _CameraParam._YOffset = _YOffset;
        _CameraParam._Speed = _Speed;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.LookAt(_Cible.transform);
        if(_PlayerData._CanMove)
            Zoom();
        
        AutoRotate();
        //FollowCible();
    }

    private void Update()
    {
        FollowCible();
    }

    void FollowCible()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _PlayerData._CibleCamera.transform.position + new Vector3(0, _CameraParam._YOffset, 0), ref velocity, _CameraParam._Speed);
    }

    void Zoom()
    {
        //Vector3 zoomVal = new Vector3(0,0,1) * (Mathf.Clamp(_CameraParam._ZoomValue * (1 - (_PlayerData._ValAngoisse / 100)), 2, 50)); 
        Vector3 zoomVal = new Vector3(0,0,1) * Mathf.Lerp(2,5.8f,(1 - (_PlayerData._ValAngoisse / 100))); 
        
        //_Camera.transform.localPosition = Vector3.SmoothDamp(_Camera.transform.localPosition, zoomVal, ref velocity, dampspeed);
        _Camera.transform.localPosition = zoomVal;
    }

    void AutoRotate()
    {        
        if(!_PlayerData._Invincible)
            transform.localRotation = _PlayerData._CibleCamera.transform.rotation;
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [Header("Data")]
    public So_Player _PlayerData;
    private Camera _Camera;

    [Header("Value")]
    public float _Speed;    
    public float _ZoomSpeed;    
    public float _ZoomValue;
    public float _YOffset;

    private Vector3 velocity = Vector3.zero;    

    // Start is called before the first frame update
    void Start()
    {
        _Camera = transform.GetChild(0).GetComponent<Camera>();        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(_Cible.transform);
        FollowCible();
        Zoom();
        //AutoRotate();
    }

    

    void FollowCible()
    {        
        transform.position = Vector3.SmoothDamp(transform.position, _PlayerData._CibleCamera.transform.position, ref velocity, _Speed);        
    }

    void Zoom()
    {
        Vector3 zoomVal = new Vector3(_Camera.transform.localPosition.x, _Camera.transform.localPosition.y, _ZoomValue);
        
        _Camera.transform.localPosition = Vector3.SmoothDamp(_Camera.transform.localPosition, zoomVal, ref velocity, _ZoomSpeed);
    }

    void AutoRotate()
    {        
        if(!_PlayerData._Invincible)
            transform.localRotation = _PlayerData._CibleCamera.transform.rotation;
    }    
}

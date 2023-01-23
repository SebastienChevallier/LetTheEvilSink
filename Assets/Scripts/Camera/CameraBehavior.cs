 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [Header("Data")]
    public So_Player _PlayerData;
    public Camera _Camera;

    [Header("Value")]
    public float _Speed;    
    public float _ZoomSpeed;

    [Range(2, 50)] public float _ZoomValue;
    public float _YOffset;

  
    private Vector3 velocity = Vector3.zero;
    

    // Start is called before the first frame update
    void Start()
    {
        _Camera = transform.GetChild(0).GetComponent<Camera>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.LookAt(_Cible.transform);
        
        Zoom();
        AutoRotate();
    }

    private void Update()
    {
        FollowCible();
    }



    void FollowCible()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _PlayerData._CibleCamera.transform.position + new Vector3(0, _YOffset, 0), ref velocity, _Speed);
    }

    void Zoom()
    {
        Vector3 zoomVal = new Vector3(0,0,1) * (Mathf.Clamp(_ZoomValue * (1 - (_PlayerData._ValAngoisse / 100)), 2, 50));        
        _Camera.transform.localPosition = zoomVal;
    }

    void AutoRotate()
    {        
        if(!_PlayerData._Invincible)
            transform.localRotation = _PlayerData._CibleCamera.transform.rotation;
    }    
}

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
    public AnimationCurve _SmoothCurve;
    public float _ZoomValue;
    public float _YOffset;
    public GameObject _Cible;

    static float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _Camera = transform.GetChild(0).GetComponent<Camera>();        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_Cible.transform);
        FollowCible();
        Zoom();
        AutoRotate();
    }

    

    void FollowCible()
    {        
        transform.position = Vector3.Lerp(transform.position, _Cible.transform.position, _SmoothCurve.Evaluate(_Speed * Time.deltaTime));        
    }

    void Zoom()
    {
        Vector3 zoomVal = new Vector3(_Camera.transform.localPosition.x, _Camera.transform.localPosition.y, _ZoomValue);
        
        _Camera.transform.localPosition = Vector3.Lerp(_Camera.transform.localPosition, zoomVal, _SmoothCurve.Evaluate(Time.deltaTime * 10f));
    }

    void AutoRotate()
    {        
        transform.localRotation = _Cible.transform.rotation;
    }    
}

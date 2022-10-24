using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [Header("Data")]
    public So_Player _PlayerData;
    private GameObject _PlayerGO;
    private GameObject _PostProcessGO;
    private Camera _Camera;

    [Header("Value")]
    public float _Speed;
    public AnimationCurve _SmoothCurve;
    public float _ZoomValue;
    public float _YOffset;
    public GameObject _Cible;

    

    // Start is called before the first frame update
    void Start()
    {
        _Camera = transform.GetChild(0).GetComponent<Camera>();
        _PlayerGO = GameObject.Find("Player");
        _PostProcessGO = GameObject.Find("PostProcess");
    }

    // Update is called once per frame
    void Update()
    {
        FollowCible();
        AutoRotate();
    }

    void FollowCible()
    {
        Vector3 zoomVal = new Vector3(_Camera.transform.localPosition.x, _Camera.transform.localPosition.y, _ZoomValue);
        Debug.Log(zoomVal);
        _Camera.transform.localPosition = zoomVal;        
        transform.position = Vector3.Lerp(transform.position, _Cible.transform.position, _SmoothCurve.Evaluate(Time.deltaTime * _Speed));        
    }

    void AutoRotate()
    {        
        transform.localRotation = _Cible.transform.rotation;
    }    
}

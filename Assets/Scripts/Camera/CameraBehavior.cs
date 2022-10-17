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
        _Camera.transform.localPosition = new Vector3(0,0, _ZoomValue);
        transform.position = Vector3.Lerp(transform.position, _Cible.transform.position, _SmoothCurve.Evaluate(Time.deltaTime * _Speed));        
    }

    void AutoRotate()
    {
        transform.rotation = new Quaternion(0, _Cible.transform.rotation.y, 0, 0);
    }

    
}

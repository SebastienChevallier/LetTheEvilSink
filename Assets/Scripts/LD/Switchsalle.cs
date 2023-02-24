using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchsalle : MonoBehaviour
{
    
    public float speedRotation;
    public float valRotaDeg;
    public float baseRotaDeg;
    public GameObject inverseTrigger;
    public GameObject inverseTrigger2;

    public bool hasColliderCam;
    public GameObject colliderCam;
    public GameObject colliderCam2;

    public GameObject obj = null;

    private Quaternion target;
    public So_Player _Player;
    public bool isTriggered = false;
    public AnimationCurve curve;


    private void Start()
    {
        target = Quaternion.Euler(0, baseRotaDeg, 0);
        temp = target;
        time = 0;
    }

    private float time;
    private void SetValueCurve()
    {
        if(time <= 1)
        {
            time += Time.deltaTime * speedRotation;
            curve.Evaluate(time);
        }
    }
    
    private void BlockPlayer()
    {
        if (curve.Evaluate(time) >= 0.9f)
        {
            _Player._CanMove = true;
        }
        else 
        {
            _Player._CanMove = false;
        }
    }
  
    private Quaternion temp;
    private void Update()
    {
        BlockPlayer();
        SetValueCurve();
        if (obj)
        {
            obj.transform.rotation = Quaternion.Slerp(temp, target, curve.Evaluate(time));
            if (Input.GetKeyDown(KeyCode.E))
            {
                temp = obj.transform.rotation;
                time = 0;
                isTriggered = true;
                Debug.Log(obj.transform.rotation.eulerAngles.y);
                if (obj.transform.rotation.eulerAngles.y <= baseRotaDeg + 0.1f)
                { 
                
                    target = Quaternion.Euler(0, valRotaDeg, 0);
                    inverseTrigger2.SetActive(true);
                    inverseTrigger.SetActive(false);
                    if (hasColliderCam)
                    {
                        colliderCam.SetActive(false);
                        colliderCam2.SetActive(true);
                    }
                }
                else
                {
                    target = Quaternion.Euler(0, baseRotaDeg, 0);
                    inverseTrigger.SetActive(true);
                    inverseTrigger2.SetActive(false);
                    if (hasColliderCam)
                    {
                        colliderCam2.SetActive(false);
                        colliderCam.SetActive(true);
                    }
                }
                obj.transform.position = new Vector3(transform.position.x, obj.transform.position.y, transform.position.z);
                
            }
            
        }
        
        
    }
}

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
    public bool isTriggered = false;


    private void Start()
    {
        target = Quaternion.Euler(0, baseRotaDeg, 0);
    }
  
    private void Update()
    {
        if (obj)
        {
            if (!isTriggered)
            {
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
            obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, target, Time.deltaTime * speedRotation);
        }
    }
}

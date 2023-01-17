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


    private void Start()
    {
        target = Quaternion.Euler(0, baseRotaDeg, 0);
    }
  
    private void Update()
    {
        if (obj)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                /*if (hasColliderCam)
                {
                    colliderCam.SetActive(false);
                    playerData._CibleCamera = obj;
                }*/
                    

                if (inverseTrigger.activeSelf)
                { 
                    target = Quaternion.Euler(0, valRotaDeg, 0);
                    inverseTrigger2.SetActive(true);
                    colliderCam2.SetActive(true);
                    inverseTrigger.SetActive(false);
                    colliderCam.SetActive(false);
                    
                }
                else
                {
                    target = Quaternion.Euler(0, baseRotaDeg, 0);
                    inverseTrigger.SetActive(true);
                    colliderCam.SetActive(true);
                    inverseTrigger2.SetActive(false);
                    colliderCam2.SetActive(false);
                    
                }
                
                obj.transform.position = new Vector3(transform.position.x, obj.transform.position.y, transform.position.z);

                
            }
            obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, target, Time.deltaTime * speedRotation);

            /*if(obj.transform.rotation == target && hasColliderCam)
                colliderCam.SetActive(true); */

        }
        
    }
}

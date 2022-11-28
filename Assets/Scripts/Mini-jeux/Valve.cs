using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    private Vector2 mousePos;
    public GameObject valve;
    public bool completed;

    private float valDegRota;

    private void Start()
    {
        mousePos = Vector2.zero;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition; 
        }

        if (Input.GetMouseButton(0))
        {
            valDegRota = valve.transform.eulerAngles.z;
            Debug.Log(valve.transform.eulerAngles.z);           
            Debug.Log(mousePos);           

            if(valDegRota <= 90)
            {
                if (Input.mousePosition.x > mousePos.x && Input.mousePosition.y > mousePos.y)
                {
                    valve.transform.Rotate(new Vector3(0, 0, 2));
                    mousePos = Input.mousePosition;
                    Debug.Log("Premier Quart");
                }
                else
                {
                    mousePos = Input.mousePosition;
                }
            }else if (valDegRota > 90 && valDegRota <= 180)
            {
                if (Input.mousePosition.x < mousePos.x && Input.mousePosition.y > mousePos.y)
                {
                    valve.transform.Rotate(new Vector3(0, 0, 2));
                    mousePos = Input.mousePosition;
                    Debug.Log("2eme Quart");
                }
                else
                {
                    mousePos = Input.mousePosition;
                }

            }
            else if (valDegRota > 180 && valDegRota <= 270)
            {
                if (Input.mousePosition.x < mousePos.x && Input.mousePosition.y < mousePos.y)
                {
                    valve.transform.Rotate(new Vector3(0, 0, 2));
                    mousePos = Input.mousePosition;
                    Debug.Log("3eme Quart");
                }
                else
                {
                    mousePos = Input.mousePosition;
                }
            }
            else if (valDegRota > 270 && valDegRota <= 360)
            {
                if (Input.mousePosition.x > mousePos.x && Input.mousePosition.y < mousePos.y)
                {
                    valve.transform.Rotate(new Vector3(0, 0, 2));
                    mousePos = Input.mousePosition;
                    Debug.Log("4eme Quart");
                }
                else
                {
                    mousePos = Input.mousePosition;
                }
            }else if (valDegRota >= 360)
            {
                completed = true;
            }




        }   
        
        
    }
}

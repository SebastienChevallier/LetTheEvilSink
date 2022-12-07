using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Valve : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 mousePos;
    public GameObject valve;
    public bool completed;

    private float valDegRota;


    private PointerEventData _lastPointerData;
    public bool dragOnSurfaces = true;

    private RectTransform m_DraggingPlane;


    public void OnBeginDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
        _lastPointerData = eventData;
        
    }

    public void OnDrag(PointerEventData data)
    {

        if (valve != null)
            SetDraggedPosition(data);
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            m_DraggingPlane = data.pointerEnter.transform as RectTransform;

        var rt = valve.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {            
            rt.rotation = m_DraggingPlane.rotation;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var rt = valve.GetComponent<RectTransform>();
        if (valve != null)
        {
            rt.localPosition = new Vector3(-200, -50, rt.position.z);
        }
        _lastPointerData = null;
    }

    public void Complete()
    {
        var rt = valve.GetComponent<RectTransform>();

    }

    public void CancelDrag()
    {
        var rt = valve.GetComponent<RectTransform>();
        if (_lastPointerData != null)
        {
            _lastPointerData.pointerDrag = null;

            rt.localPosition = new Vector3(-200, -50, rt.position.z);
        }
    }

    private void Start()
    {
        mousePos = Vector2.zero;
    }

    // Update is called once per frame
    /*void Update()
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
        
        
    }*/
}

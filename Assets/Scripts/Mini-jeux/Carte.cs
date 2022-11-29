using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Carte : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject carte;
    public bool completed;
    public float minTime;
    public float maxTime;

    public bool dragOnSurfaces = true;

    public float timer;

    private PointerEventData _lastPointerData;


    private RectTransform m_DraggingPlane;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
        }

        Complete();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
        _lastPointerData = eventData;
        timer = 0;
    }

    public void OnDrag(PointerEventData data)
    {
        
        if (carte != null)
            SetDraggedPosition(data);
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            m_DraggingPlane = data.pointerEnter.transform as RectTransform;

        var rt = carte.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = new Vector3(globalMousePos.x, rt.position.y, rt.position.z);
            
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var rt = carte.GetComponent<RectTransform>();
        if (carte != null)
        {
            rt.localPosition = new Vector3(-200, -50, rt.position.z);
        }
        _lastPointerData = null;
    }

    public void Complete()
    {
        var rt = carte.GetComponent<RectTransform>();

        if(rt.localPosition.x >= 250)
        {
            if(timer > minTime && timer < maxTime)
            {
                completed = true;
                Debug.Log("Complete");
                CancelDrag();
            }
            else if (timer < minTime)
            {
                Debug.Log("Trop Rapide");
                CancelDrag();
            }
            else if (timer > maxTime)
            {
                Debug.Log("Trop Lent");
                CancelDrag();
            }
        }
    }

    public void CancelDrag()
    {
        var rt = carte.GetComponent<RectTransform>();
        if (_lastPointerData != null)
        {
            _lastPointerData.pointerDrag = null;

            rt.localPosition = new Vector3(-200, -50, rt.position.z);
        }
    }

}

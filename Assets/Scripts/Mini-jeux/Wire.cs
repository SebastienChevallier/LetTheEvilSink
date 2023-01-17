using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool IsLeftWire;  
    private Image _image;

    public Color CustomColor;

    private LineRenderer _lineRenderer;

    private Canvas _canvas;

    private bool _isDragStarted = false;
    public WireTask _wireTask;

    public bool isSuccess = false;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = transform.parent.GetComponentInParent<Canvas>();
        _wireTask = transform.parent.GetComponentInParent<WireTask>();
    }

    private void Update()
    {
        if (_isDragStarted)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _canvas.transform as RectTransform,
                    Input.mousePosition,
                    _canvas.worldCamera,
                    out movePos
                );
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos));
        }
        else
        {
            if (!isSuccess)
            {
                _lineRenderer.SetPosition(0, Vector3.zero);
                _lineRenderer.SetPosition(1, Vector3.zero);
            }
            
        }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, _canvas.worldCamera);

        if (isHovered)
        {
            _wireTask.CurrentHoveredWire = this;
        }
    }

    public void SetColor(Color color)
    {
        _image.color = color;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        CustomColor = color;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsLeftWire) { return; }
        if(isSuccess) { return; }
        _isDragStarted = true;
        _wireTask.CurrentDraggedWire = this;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(_wireTask.CurrentHoveredWire != null)
        {
            if(_wireTask.CurrentHoveredWire.CustomColor == CustomColor && !_wireTask.CurrentHoveredWire.IsLeftWire)
            {
                isSuccess = true;
                _wireTask.CurrentHoveredWire.isSuccess = true;
            }
        }


        _isDragStarted = false;
        _wireTask.CurrentDraggedWire = null;
    }
}

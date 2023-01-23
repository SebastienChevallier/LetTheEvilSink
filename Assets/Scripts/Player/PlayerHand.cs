using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public Transform hand;
    public Transform panelTop;
    public Transform panelLeft;
    public Transform panelRight;

    private DragAndHover[] handContent;

    void Start()
    {
        handContent = hand.GetComponentsInChildren<DragAndHover>();
        foreach (DragAndHover dnh in handContent)
        {
            dnh.canDrag = true;
            dnh.canHover = true;
        }
    }

    public void CantHover()
    {
        foreach (DragAndHover dnh in handContent)
        {
            dnh.canHover = false;
        }
    }

    public void CanHover()
    {
        foreach (DragAndHover dnh in handContent)
        {
            dnh.canHover = true;
        }
    }
}
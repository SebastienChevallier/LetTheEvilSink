using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tuyauterie : MonoBehaviour, IPointerClickHandler
{
    public bool isPuzzle;

    public float actualRotation;
    public float puzzleRotation;

    private GridManager gridManager;


    void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 90);
            actualRotation = transform.eulerAngles.z;

            Debug.Log(actualRotation);
            Debug.Log(puzzleRotation);

            gridManager.CheckPuzzle();
        }
    }
}

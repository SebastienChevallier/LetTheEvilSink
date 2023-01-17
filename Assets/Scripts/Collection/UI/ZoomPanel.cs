using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomPanel : MonoBehaviour, IPointerClickHandler
{
    private _CollectionManager collectionManager;



    void Start()
    {
        collectionManager = FindObjectOfType<_CollectionManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            gameObject.SetActive(false);
        }
    }
}

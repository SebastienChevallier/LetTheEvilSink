using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{



    public void OnPointerClick(PointerEventData eventData)
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 90);
    }
}

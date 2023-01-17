using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndHover : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private PlayerHand playerHand;

    [Header("Card Properties")]
    public CardInfo card;
    public CanvasGroup canvasGroup;
    public Canvas canvas;

    [Header("Card Hover")]
    [HideInInspector] public bool canHover = false;

    [Header("Card Drag")]
    public GameObject EmptyCard;
    [HideInInspector] public bool canDrag = false;
    [HideInInspector] public Transform parentReturnTo = null;
    [HideInInspector] public GameObject temp;

    private void Start()
    {
        playerHand = gameObject.GetComponentInParent<PlayerHand>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!canHover) return;

        card.transform.localScale = new Vector2(0.8f, 0.8f);
        card.transform.localPosition = new Vector3(card.transform.localPosition.x, 180f, 10f);
        canvas.sortingOrder = 2;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!canHover) return;

        card.transform.localScale = new Vector2(0.5f, 0.5f);
        card.transform.localPosition = new Vector2(card.transform.localPosition.x, 0);
        canvas.sortingOrder = 1;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!canDrag) return;

        temp = Instantiate(EmptyCard);
        temp.transform.SetParent(transform.parent, false);
        temp.transform.SetSiblingIndex(transform.GetSiblingIndex());

        parentReturnTo = transform.parent;
        transform.SetParent(transform.parent.parent, false);

        canvasGroup.blocksRaycasts = false;
        playerHand.CantHover();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag) return;

        Vector3 screenPoint = eventData.position;
        screenPoint.z = 10.0f;
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

        int newSiblingIndex = parentReturnTo.childCount;

        for (int i = 0; i < parentReturnTo.childCount; i++)
        {
            if (transform.position.x < parentReturnTo.GetChild(i).position.x)
            {
                newSiblingIndex = i;
                if (temp.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }
                break;
            }
        }

        // IN HAND
        if (transform.position.y < playerHand.panelTop.position.y &&
                transform.position.x > playerHand.panelLeft.position.x &&
                transform.position.x < playerHand.panelRight.position.x)
        {
            transform.localScale = new Vector2(0.5f, 0.5f);
            temp.transform.SetSiblingIndex(newSiblingIndex);
            canvas.sortingOrder = 2;
        }
        // OUTSIDE OF HAND
        else
        {
            transform.localScale = new Vector2(0.3f, 0.3f);
            canvas.sortingOrder = 0;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!canDrag) return;

        transform.SetParent(parentReturnTo, false);
        transform.SetSiblingIndex(temp.transform.GetSiblingIndex());
        canvasGroup.blocksRaycasts = true;

        Destroy(temp);
        card.transform.localScale = new Vector2(0.5f, 0.5f);
        playerHand.CanHover();
    }
}
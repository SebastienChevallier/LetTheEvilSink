using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("UI")]
    [HideInInspector] public Image image;

    [Header("Properties")]
    public Vector2 coord;
    public string tileName;

    [Header("Field Card")]
    public GameObject fieldCardPrefab;


    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag)
        {
            image.color = new Color(0, 255, 0, 0.35f);
        }
        else
        {
            image.color = new Color(0, 0, 0, 0.5f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(0, 0, 0, 0.24f);
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject drop = eventData.pointerDrag;

        if (drop && transform.childCount == 0)
        {
            GameObject boardCard = Instantiate(fieldCardPrefab, Vector3.zero, Quaternion.identity, transform);
            boardCard.transform.localPosition = Vector3.zero;
            boardCard.GetComponent<FieldCard>().tileInfo = this;

            CardInfo handCard = drop.GetComponent<CardInfo>();
            FindObjectOfType<GAMEMANAGER>().cardPlayed = handCard;

            Destroy(drop.GetComponent<DragAndHover>().temp);
            Destroy(drop);

            FindObjectOfType<PlayerHand>().CanHover();
        }
    }
}
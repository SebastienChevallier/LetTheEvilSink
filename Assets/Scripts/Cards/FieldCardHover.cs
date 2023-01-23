using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class FieldCardHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Sprite")]
    public Image image;

    [Header("Properties")]
    public Text cardName;
    public Text cost;
    public Text strength;
    public Text health;
    public Text effect;
    public Text creatureType;

    [Header("Card Hover")]
    public GameObject cardHover;



    private void Start()
    {
        CardInfo fieldCard = FindObjectOfType<FieldCard>().cardPlayed;

        image.sprite = fieldCard.image;
        cardName.text = fieldCard.name;
        cost.text = fieldCard.cost.ToString();
        strength.text = fieldCard.strength.ToString();
        health.text = fieldCard.maxHealth.ToString();
        effect.text = fieldCard.effect.ToString();
        creatureType.text = fieldCard.creatureType.ToString();
        cardHover.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cardHover.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cardHover.SetActive(false);
    }
}
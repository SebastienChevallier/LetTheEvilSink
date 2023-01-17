using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DeckCard : MonoBehaviour, IPointerClickHandler
{
    private _CollectionManager collectionManager;

    [Header("UI")]
    public TextMeshProUGUI numberText;
    public int cardUnit = 0;



    private void Start()
    {
        collectionManager = FindObjectOfType<_CollectionManager>();

        numberText.text = cardUnit.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Left Click
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (cardUnit > 0)
            {
                GameObject collectionCard;

                if (!collectionManager.CheckDoubleton(collectionManager.collection, gameObject))
                {
                    collectionCard = collectionManager.GetDoubleton(collectionManager.removedCollection, gameObject);
                    collectionCard.SetActive(true);
                    collectionManager.removedCollection.Remove(collectionCard);
                }
                else
                {
                    collectionCard = collectionManager.GetDoubleton(collectionManager.collection, gameObject);
                }

                collectionCard.GetComponent<CollectionCard>().cardUnit++;
                collectionCard.GetComponent<CollectionCard>().numberText.text = collectionCard.GetComponent<CollectionCard>().cardUnit.ToString();

                cardUnit--;
                numberText.text = cardUnit.ToString();

                collectionManager.collection.Add(collectionCard);
                collectionManager.deck.Remove(gameObject);

                if (cardUnit == 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        // Right click
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            collectionManager.OpenZoomCardPanel();

            CardInfo zoomCardInfo = collectionManager.zoomCard.GetComponent<CardInfo>();

            if (GetComponent<CardInfo>().creatureCard)
            {
                zoomCardInfo.creatureCard = GetComponent<CardInfo>().creatureCard;
                zoomCardInfo.spellCard = null;
            }
            else if (GetComponent<CardInfo>().spellCard)
            {
                zoomCardInfo.creatureCard = null;
                zoomCardInfo.spellCard = GetComponent<CardInfo>().spellCard;
            }
            
            zoomCardInfo.SetStats();
            zoomCardInfo.SetUI();
        }
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CollectionCard : MonoBehaviour, IPointerClickHandler
{
    private _CollectionManager collectionManager;

    [Header("UI")]
    public TextMeshProUGUI numberText;
    public int cardUnit = 3;



    private void Start()
    {
        collectionManager = FindObjectOfType<_CollectionManager>();

        numberText.text = cardUnit.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Left click
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (cardUnit > 0)
            {
                GameObject deckCard;

                if (!collectionManager.CheckDoubleton(collectionManager.deck, gameObject))
                {
                    int index = OrderDeck(GetComponent<CardInfo>());
                    deckCard = Instantiate(collectionManager.deckCardPrefab, Vector3.zero, Quaternion.identity, collectionManager.deckContent);
                    deckCard.transform.SetSiblingIndex(index);

                    if (GetComponent<CardInfo>().creatureCard)
                    {
                        deckCard.GetComponent<CardInfo>().creatureCard = GetComponent<CardInfo>().creatureCard;
                    }
                    else if (GetComponent<CardInfo>().spellCard)
                    {
                        deckCard.GetComponent<CardInfo>().spellCard = GetComponent<CardInfo>().spellCard;
                    }

                    deckCard.GetComponent<CardInfo>().SetStats();
                }

                else
                {
                    deckCard = collectionManager.GetDoubleton(collectionManager.deck, gameObject);
                }
                
                deckCard.GetComponent<DeckCard>().cardUnit++;
                deckCard.GetComponent<DeckCard>().numberText.text = deckCard.GetComponent<DeckCard>().cardUnit.ToString();

                cardUnit--;
                numberText.text = cardUnit.ToString();

                collectionManager.deck.Add(deckCard);
                collectionManager.collection.Remove(gameObject);

                if (cardUnit == 0)
                {
                    collectionManager.removedCollection.Add(gameObject);
                    gameObject.SetActive(false);
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

    private int OrderDeck(CardInfo card)
    {
        int index = 0;

        foreach (Transform child in collectionManager.deckContent)
        {
            if ((int)card.spellType < (int)child.GetComponent<CardInfo>().spellType)
            {
                break;
            }
            else if ((int)card.spellType == (int)child.GetComponent<CardInfo>().spellType)
            {
                if (card.cost < child.GetComponent<CardInfo>().cost)
                {
                    break;
                }
                else if (card.cost == child.GetComponent<CardInfo>().cost)
                {
                    if (card.name.CompareTo(child.GetComponent<CardInfo>().name) < 0)
                    {
                        break;
                    }
                }
            }

            index++;
        }

        return index;
    }
}

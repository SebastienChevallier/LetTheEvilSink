using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class _CollectionManager : MonoBehaviour
{
    [Header("Game")]
    public SO_Database database;

    [Header("Collection")]
    public Transform collectionContent;
    public GameObject collectionCardPrefab;
    public List<GameObject> collection;
    [HideInInspector] public List<GameObject> removedCollection;

    [Header("Deck")]
    public Transform deckContent;
    public GameObject deckCardPrefab;
    public List<GameObject> deck;

    [Header("UI")]
    public TMP_InputField textField;
    public GameObject zoomCardPanel;
    public GameObject zoomCard;

    // Buttons
    [HideInInspector] public Image costButton;
    [HideInInspector] public Image strengthButton;
    [HideInInspector] public Image healthButton;
    [HideInInspector] public Image typeButton;
    [HideInInspector] public Image cardButton;

    // Filters
    [HideInInspector] public string nameFilter;
    [HideInInspector] public int costFilter;
    [HideInInspector] public int strengthFilter;
    [HideInInspector] public int healthFilter;
    [HideInInspector] public CreatureType creatureTypeFilter;
    [HideInInspector] public int cardFilter;



    private void Start()
    {
        // Load collection
        foreach (ScriptableObject card in database.database)
        {
            GameObject collectionCard = Instantiate(collectionCardPrefab, Vector3.zero, Quaternion.identity, collectionContent);

            if (card.GetType() == typeof(SO_CreatureCard))
            {
                collectionCard.GetComponent<CardInfo>().creatureCard = (SO_CreatureCard)card;
            }
            else if (card.GetType() == typeof(SO_SpellCard))
            {
                collectionCard.GetComponent<CardInfo>().spellCard = (SO_SpellCard)card;
            }

            collectionCard.GetComponent<CardInfo>().SetStats();

            for (int i = 0; i < collectionCard.GetComponent<CollectionCard>().cardUnit; i++)
            {
                collection.Add(collectionCard);
            }
        }
    }

    public void SearchByName(string name)
    {
        nameFilter = name;
        ApplyFilters();
    }

    public void ApplyFilters()
    {
        foreach (GameObject go in collection)
        {
            // Reset all gameobjects before checking again with new filters
            go.SetActive(true);

            if (nameFilter != "")
            {
                if (!go.GetComponent<CardInfo>().name.ToLower().Contains(nameFilter.ToLower()))
                {
                    go.SetActive(false);
                }
            }
            if (costFilter != 0)
            {
                if (go.GetComponent<CardInfo>().cost != costFilter)
                {
                    go.SetActive(false);
                }
            }
            if (strengthFilter != 0)
            {
                if (strengthFilter == 10)
                {
                    if (go.GetComponent<CardInfo>().strength < strengthFilter)
                    {
                        go.SetActive(false);
                    }
                }
                else if (go.GetComponent<CardInfo>().strength != strengthFilter)
                {
                    go.SetActive(false);
                }
            }
            if (healthFilter != 0)
            {
                if (healthFilter == 10)
                {
                    if (go.GetComponent<CardInfo>().maxHealth < healthFilter)
                    {
                        go.SetActive(false);
                    }
                }
                else if (go.GetComponent<CardInfo>().maxHealth != healthFilter)
                {
                    go.SetActive(false);
                }
            }
            if (creatureTypeFilter != CreatureType.None)
            {
                if (go.GetComponent<CardInfo>().creatureType != creatureTypeFilter)
                {
                    go.SetActive(false);
                }
            }
            if (cardFilter != 0)
            {
                if (cardFilter == 1)
                {
                    if (go.GetComponent<CardInfo>().creatureType == CreatureType.None)
                    {
                        go.SetActive(false);
                    }
                }
                else if (cardFilter == 2)
                {
                    if (go.GetComponent<CardInfo>().spellType == SpellType.None)
                    {
                        go.SetActive(false);
                    }
                }
            }
        }
    }

    public void ResetFilters()
    {
        nameFilter = "";
        costFilter = 0;
        strengthFilter = 0;
        healthFilter = 0;
        creatureTypeFilter = CreatureType.None;
        cardFilter = 0;

        textField.text = "";
        if (costButton)
        {
            costButton.color = new Color(costButton.color.r, costButton.color.g, costButton.color.b, 0.35f);
        }
        if (strengthButton)
        {
            strengthButton.color = new Color(strengthButton.color.r, strengthButton.color.g, strengthButton.color.b, 0.35f);
        }
        if (healthButton)
        {
            healthButton.color = new Color(healthButton.color.r, healthButton.color.g, healthButton.color.b, 0.35f);
        }
        if (typeButton)
        {
            typeButton.color = new Color(typeButton.color.r, typeButton.color.g, typeButton.color.b, 0.35f);
        }
        if (cardButton)
        {
            cardButton.color = new Color(cardButton.color.r, cardButton.color.g, cardButton.color.b, 0.35f);
        }

        foreach (GameObject go in collection)
        {
            go.SetActive(true);
        }
    }

    public bool CheckDoubleton(List<GameObject> list, GameObject card)
    {
        foreach (GameObject go in list)
        {
            if (go.GetComponent<CardInfo>().name == card.GetComponent<CardInfo>().name)
            {
                return true;
            }
        }

        return false;
    }

    public GameObject GetDoubleton(List<GameObject> list, GameObject card)
    {
        foreach (GameObject go in list)
        {
            if (go.GetComponent<CardInfo>().name == card.GetComponent<CardInfo>().name)
            {
                return go;
            }
        }

        return null;
    }

    public void OpenZoomCardPanel()
    {
        if (zoomCardPanel.activeSelf)
        {
            zoomCardPanel.SetActive(false);
        }
        else
        {
            zoomCardPanel.SetActive(true);
        }
    }
}

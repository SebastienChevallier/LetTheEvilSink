using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelFilterButtons : MonoBehaviour, IPointerClickHandler
{
    [Header("Manager")]
    private _CollectionManager collectionManager;

    [Header("UI")]
    private Image image;

    [Header("Filters")]
    public int buttonCost;
    public int buttonStrength;
    public int buttonHealth;
    public CreatureType buttonType;
    public int buttonCard;



    private void Start()
    {
        collectionManager = FindObjectOfType<_CollectionManager>();

        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.35f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Filters

            if (buttonCost != 0)
            {
                if (collectionManager.costFilter != buttonCost)
                {
                    if (collectionManager.costButton)
                    {
                        collectionManager.costButton.color = new Color(collectionManager.costButton.color.r, collectionManager.costButton.color.g, collectionManager.costButton.color.b, 0.35f);
                    }
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
                    collectionManager.costButton = image;
                    collectionManager.costFilter = buttonCost;
                }
                else
                {
                    image.color = new Color(collectionManager.costButton.color.r, collectionManager.costButton.color.g, collectionManager.costButton.color.b, 0.35f);
                    collectionManager.costButton = null;
                    collectionManager.costFilter = 0;
                }
            }
            else if (buttonStrength != 0)
            {
                if (collectionManager.strengthFilter != buttonStrength)
                {
                    if (collectionManager.strengthButton)
                    {
                        collectionManager.strengthButton.color = new Color(collectionManager.strengthButton.color.r, collectionManager.strengthButton.color.g, collectionManager.strengthButton.color.b, 0.35f);
                    }
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
                    collectionManager.strengthButton = image;
                    collectionManager.strengthFilter = buttonStrength;
                }
                else
                {
                    image.color = new Color(collectionManager.strengthButton.color.r, collectionManager.strengthButton.color.g, collectionManager.strengthButton.color.b, 0.35f);
                    collectionManager.strengthButton = null;
                    collectionManager.strengthFilter = 0;
                }
            }
            else if (buttonHealth != 0)
            {
                if (collectionManager.healthFilter != buttonHealth)
                {
                    if (collectionManager.healthButton)
                    {
                        collectionManager.healthButton.color = new Color(collectionManager.healthButton.color.r, collectionManager.healthButton.color.g, collectionManager.healthButton.color.b, 0.35f);
                    }
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
                    collectionManager.healthButton = image;
                    collectionManager.healthFilter = buttonHealth;
                }
                else
                {
                    image.color = new Color(collectionManager.healthButton.color.r, collectionManager.healthButton.color.g, collectionManager.healthButton.color.b, 0.35f);
                    collectionManager.healthButton = null;
                    collectionManager.healthFilter = 0;
                }
            }
            else if (buttonType != CreatureType.None)
            {
                if (collectionManager.creatureTypeFilter != buttonType)
                {
                    if (collectionManager.typeButton)
                    {
                        collectionManager.typeButton.color = new Color(collectionManager.typeButton.color.r, collectionManager.typeButton.color.g, collectionManager.typeButton.color.b, 0.35f);
                    }
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
                    collectionManager.typeButton = image;
                    collectionManager.creatureTypeFilter = buttonType;
                }
                else
                {
                    image.color = new Color(collectionManager.typeButton.color.r, collectionManager.typeButton.color.g, collectionManager.typeButton.color.b, 0.35f);
                    collectionManager.typeButton = null;
                    collectionManager.creatureTypeFilter = CreatureType.None;
                }
            }
            else if (buttonCard != 0)
            {
                if (collectionManager.cardFilter != buttonCard)
                {
                    if (collectionManager.cardButton)
                    {
                        collectionManager.cardButton.color = new Color(collectionManager.cardButton.color.r, collectionManager.cardButton.color.g, collectionManager.cardButton.color.b, 0.35f);
                    }

                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
                    collectionManager.cardButton = image;
                    collectionManager.cardFilter = buttonCard;
                }
                else
                {
                    image.color = new Color(collectionManager.cardButton.color.r, collectionManager.cardButton.color.g, collectionManager.cardButton.color.b, 0.35f);
                    collectionManager.typeButton = null;
                    collectionManager.cardFilter = 0;
                }
            }

            // Apply filters
            collectionManager.ApplyFilters();
        }
    }
}

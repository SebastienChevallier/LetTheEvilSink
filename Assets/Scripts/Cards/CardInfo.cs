using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    [Header("Card Data")]
    public SO_CreatureCard creatureCard;
    public SO_SpellCard spellCard;

    [Header("Sprite")]
    public Image cardImage;

    [Header("Properties")]
    public Text cardName;
    public Text cardCost;
    public Text cardStrength;
    public Text cardHealth;
    public Text cardEffect;
    public Text cardCreatureType;

    public Text cardSpellType;

    [HideInInspector] public new string name;
    [HideInInspector] public Sprite image;
    [HideInInspector] public int cost;
    [HideInInspector] public int strength;
    [HideInInspector] public int maxHealth;
    [HideInInspector] public int currentHealth;
    [HideInInspector] public string effect;

    [HideInInspector] public CreatureType creatureType;

    [HideInInspector] public MovementPattern pattern;
    [HideInInspector] public int moveValue;


    [HideInInspector] public SpellType spellType;



    private void Awake()
    {
        SetStats();
    }

    private void Start()
    {
        SetUI();
    }

    public void SetUI()
    {
        cardImage.sprite = image;
        cardName.text = name;
        cardCost.text = cost.ToString();
        cardStrength.text = strength.ToString();
        cardHealth.text = maxHealth.ToString();
        cardEffect.text = effect.ToString();
        cardCreatureType.text = creatureType.ToString();
        cardSpellType.text = spellType.ToString();
    }

    public void SetStats()
    {
        if (creatureCard)
        {
            image = creatureCard.image;
            name = creatureCard.name;
            cost = creatureCard.cost;
            strength = creatureCard.strength;
            maxHealth = creatureCard.maxHealth;
            currentHealth = creatureCard.currentHealth;
            effect = creatureCard.effect;

            creatureType = creatureCard.type;

            pattern = creatureCard.pattern;
            moveValue = creatureCard.moveValue;

            spellType = SpellType.None;

        }
        else if (spellCard)
        {
            image = spellCard.image;
            name = spellCard.name;
            cost = spellCard.cost;
            strength = 0;
            maxHealth = 0;
            currentHealth = 0;
            effect = spellCard.effect;

            creatureType = CreatureType.None;

            pattern = MovementPattern.None;
            moveValue = 0;

            spellType = spellCard.type;
        }
    }
}

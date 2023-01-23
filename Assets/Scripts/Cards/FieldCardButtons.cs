using UnityEngine;

public class FieldCardButtons : MonoBehaviour
{
    public FieldCard card;

    public void AddAttack()
    {
        card.cardPlayed.strength++;
        card.strength.text = card.cardPlayed.strength.ToString();
    }

    public void RemoveAttack()
    {
        card.cardPlayed.strength--;
        card.strength.text = card.cardPlayed.strength.ToString();
    }

    public void AddHealth()
    {
        card.cardPlayed.currentHealth++;
        card.cardPlayed.maxHealth++;
        card.health.text = card.cardPlayed.currentHealth.ToString();
    }

    public void RemoveHealth()
    {
        card.cardPlayed.currentHealth--;
        card.cardPlayed.maxHealth--;
        card.health.text = card.cardPlayed.currentHealth.ToString();

        if (card.cardPlayed.currentHealth <= 0)
        {
            Destroy(card.gameObject);
        }
    }
}


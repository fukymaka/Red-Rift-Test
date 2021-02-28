using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Text titleText;
    public Text descriptionText;
    public Text manaText;
    public Text attackText;
    public Text healthText;
    public int mana;
    public int attack;
    public int health;

    private CardSO card;


    private void Start()
    {
        card = CardController.S.GetRandomCardValues();

        titleText.text = card.title;
        descriptionText.text = card.description;
        manaText.text = card.mana.ToString();
        attackText.text = card.attack.ToString();
        healthText.text = card.health.ToString();

        mana = card.mana;
        attack = card.attack;
        health = card.health;

    }


    private void Update()
    {
        manaText.text = mana.ToString();
        attackText.text = attack.ToString();
        healthText.text = health.ToString();
    }
}

using UnityEngine;


[CreateAssetMenu(fileName = "Card_", menuName = "Card")]
public class CardSO : ScriptableObject
{
    [Header("Title card")]
    public string title;

    [Header("Description card")]
    public string description;

    [Header("Mana cost")]
    public int mana;

    [Header("Attack value")]
    public int attack;

    [Header("Health count")]
    public int health;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public static CardController S;

    public GameObject fanWay;
    public GameObject cardPrefab;
    public GameObject cardsPanel;
    public List<CardSO> cardsSo = new List<CardSO>();
    public List<GameObject> cardList;

    private List<Card> cardValues = new List<Card>();
    private int currentCardIndex = 0;


    private void Awake()
    {
        S = this;
    }


    public GameObject CreateCard()
    {
        GameObject card = Instantiate(cardPrefab, cardsPanel.transform);
        cardList.Add(card);
        cardValues.Add(card.GetComponent<Card>());

        return card;
    }


    public CardSO GetRandomCardValues()
    {
        int randomIndex = Random.Range(0, cardsSo.Count);
        CardSO randomCard = cardsSo[randomIndex];
        cardsSo.Remove(cardsSo[randomIndex]);

        return randomCard;
    }


    public void ChangeRandomValueCard()
    {
        if (cardList.Count == 0)
        {
            Debug.Log("Cards is end");
            return;
        }

        int randomValue = Random.Range(0, 3);

        switch (randomValue)
        {
            case 0:
                cardValues[currentCardIndex].mana = Random.Range(-2, 9);
                break;
            case 1:
                cardValues[currentCardIndex].attack = Random.Range(-2, 9);
                break;
            case 2:
                cardValues[currentCardIndex].health = Random.Range(-2, 9);
                break;
        }

        if (cardValues[currentCardIndex].health < 1)
        {
            StartCoroutine(DestroyCard(cardList[currentCardIndex]));
            cardList.Remove(cardList[currentCardIndex]);
            cardValues.Remove(cardValues[currentCardIndex]);
            
            fanWay.GetComponent<FanWay>().RemovePoint(currentCardIndex);
        }

        currentCardIndex++;

        if (currentCardIndex >= cardValues.Count)
        {
            currentCardIndex = 0;
        }
    }


    IEnumerator DestroyCard(GameObject card)
    {
        card.GetComponent<Animator>().SetTrigger("Fade");

        yield return new WaitForSeconds(1);

        Destroy(card);
    }
}

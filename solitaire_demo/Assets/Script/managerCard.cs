using System;
using System.Collections.Generic;
using UnityEngine;

public class managerCard : MonoBehaviour
{
    public Sprite[] faceCard;
    public GameObject cardPrefab; 

    public static string[] setCard = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public List<string> deckCard = new List<string>();

    void Start()
    {
        DealCard();
    }

    void Update()
    {
        
    }

    public void DealCard()
    {
        deckCard = GenerateDeck();
        ShuffleCard(deckCard);

        foreach (var card in deckCard)
        {
            print(card);
        }
        createDeck(); 
    }

    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();

        foreach (var s in setCard)
        {
            foreach (var v in values)
            {
                newDeck.Add(s + v);
            }
        }
        return newDeck;
    }

    void ShuffleCard<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;

        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    public void createDeck()
    {
        float ySet = 0f;
        float zSet = 0f; 

        foreach (var cardName in deckCard)
        {
            // GameObject newCard = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            GameObject newCard = Instantiate(cardPrefab,new Vector3(transform.position.x, transform.position.y - ySet, transform.position.z - zSet) , Quaternion.identity);
            newCard.name = cardName;

            ySet = ySet + 0.1f;
            zSet = zSet + 0.03f; 
        }
    }
}
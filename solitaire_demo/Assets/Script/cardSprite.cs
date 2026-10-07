using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class cardSprite : MonoBehaviour 
{
    
    public Sprite faceCard;
    public Sprite backCard;
    SpriteRenderer displayCard;
    managerCard c_managerCard;
    Selectable c_Selectable; 

    void Start() 
    {
        setDeck(); 
    }

    void Update() 
    {
        if (c_Selectable.faceUp == true) 
        {
            displayCard.sprite = faceCard; 
        }
        else
        {
            displayCard.sprite = backCard;
        }
    }
    void setDeck()
    {
        List<string> deck = managerCard.GenerateDeck();
        c_managerCard = FindAnyObjectByType<managerCard>();

        int indexs = 0; 

        foreach (var card in deck)
        {
            if(this.name == card)
            {
                faceCard = c_managerCard.faceCard[indexs];
                break; 
            }
            indexs++; 
        }
        displayCard = GetComponent<SpriteRenderer>();
        c_Selectable = GetComponent<Selectable>();
    }
}

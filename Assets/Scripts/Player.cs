using System;
using System.Collections.Generic;
using System.Collections;
using Random = UnityEngine.Random;

[Serializable]
public class Player
{
    public List<Card> playerDeck = new List<Card>();
    public List<Card> playerHand = new List<Card>();
    public List<Card> playerBoard= new List<Card>();
    public bool[] availableSlots=new bool[5];
    public bool cardPlayed;
    public int energy;

    public Player()
    {
        for (int i = 0; i < availableSlots.Length; i++)
        {
            availableSlots[i] = true;
        }

        cardPlayed = false;
        energy = 0;
        
    }
    public Card FindByNameBoard(string name)
    {
        for (int i = 0; i < playerBoard.Count; i++)
        {
            if (playerBoard[i].cardName.Equals(name))
                return playerBoard[i];
        }
        
        return null;
    }
    public Card FindByNameHand(string name)
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            if (playerHand[i].name.Equals(name))
                return playerHand[i];
        }

        return null;
    }

    public override string ToString()
    {
        string ans = "";
        ans += "deck size: " + playerDeck.Count+"\n";
        ans += "deck: ";
        for (int i = 0; i < playerDeck.Count; i++)
        {
            ans += i + 1 + ": " + playerDeck[i].name + ",";
        }
        ans += "hand size: " + playerHand.Count + "\n";
        ans += "hand: ";
        for (int i = 0; i < playerHand.Count; i++)
        {
            ans += i + 1 + ": " + playerHand[i].name + ",";
        }
        return ans;
    }

    
}
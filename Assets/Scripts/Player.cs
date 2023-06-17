using System.Collections.Generic;
using System.Collections;
public class Player
{
    public List<Card> playerDeck = new List<Card>();
    public List<Card> playerHand = new List<Card>();
    public List<Card> playerBoard= new List<Card>();
    public bool[] availableSlots;
    public bool cardPlayed;
    public int energy;
}
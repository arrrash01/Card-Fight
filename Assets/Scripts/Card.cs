using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
    public string cardName;
    public int energyCost;
    public int hp;
    public int damage;
    public CardType type;
    public Sprite artwork;
    public string description;

}

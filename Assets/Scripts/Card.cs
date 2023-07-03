using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
    public string cardName;
    public int energyCost;
    public int maxhp;
    public int hp;
    public int damage;
    public CardType type;
    public Sprite Blueartwork;
    public Sprite Redartwork;
    public string description;
    public bool isHuman;
    public bool isFacility;
    public int level;
    public int turnBombed=-2;
    public int damageToTake;
    public void LevelUp(LevelUpProgression levelUpProgression)
    {
        // Increase the character's level
        level++;

        // Retrieve the HP and damage increases from the level up progression
        int hpIncrease = levelUpProgression.GetHPIncrease(cardName, level);
        int damageIncrease = levelUpProgression.GetDamageIncrease(cardName, level);

        // Apply the HP and damage increases
        maxhp += hpIncrease;
        hp = maxhp;
        damage += damageIncrease;
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Player enemy;
    public List<Card> allCards = new List<Card>();
    public int turn;
    public GameObject blueBoard;
    public GameObject redBoard;

    public bool PlayCard(Card pCard)
    {
        if (player.cardPlayed)
        {
            return false;
        }
        player.cardPlayed = true; 
        player.playerHand.Remove(pCard);
        PlaceCard(pCard);
        ShowCards();
        return true;
    }

    public void PlaceCard(Card pCard)
    {
        for (int i = 0;i < player.availableSlots.Length; i++)
        {
            if (player.availableSlots[i])
            {
                player.availableSlots[i] = false;
                player.playerBoard.Add(pCard);
                return;
            }
        }
    }

    public void Attack(Card attacker,Card enemyCard = null)
    {
        if (player.energy < attacker.energyCost)
        {
            return;
        }
        bool trenchExists=false;
        if (enemy.FindByNameBoard("سنگر") != null)
            trenchExists = true;
        var index=player.playerBoard.IndexOf(attacker);
        switch (attacker.type)
        {
            case CardType.Gunman: 
                Debug.Log("gunman attack");
                if (enemy.playerBoard.Count > index)
                {
                    if (trenchExists)
                    {
                        enemy.FindByNameBoard("سنگر").hp -= attacker.damage;
                        if (enemy.FindByNameBoard("سنگر").hp <= 0)
                            enemy.playerBoard.Remove(enemy.FindByNameBoard("سنگر"));
                    }
                    else
                    {
                        enemy.playerBoard[index].hp -= attacker.damage;
                        if (enemy.playerBoard[index].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index]);
                        }
                    }
                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.Tank: 
                Debug.Log("Tank attack");
                if (enemy.playerBoard.Count > index)
                {
                    if (trenchExists)
                    {
                        enemy.FindByNameBoard("سنگر").hp -= attacker.damage;
                        if (enemy.FindByNameBoard("سنگر").hp <= 0)
                            enemy.playerBoard.Remove(enemy.FindByNameBoard("سنگر"));
                    }
                    else
                    {
                        enemy.playerBoard[index].hp -= attacker.damage;
                        if (enemy.playerBoard[index].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index]);
                        }
                    }

                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.Helli: 
                Debug.Log("Hellicopter attack");
                if (enemy.playerBoard.Count > index)
                {
                    if (trenchExists)
                    {
                        enemy.FindByNameBoard("سنگر").hp -= attacker.damage;
                    }
                    else
                    {
                        enemy.playerBoard[index].hp -= attacker.damage;
                        if (enemy.playerBoard[index].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index]);
                        }
                    }

                    if (index > 0)
                    {
                        if(trenchExists)
                            enemy.FindByNameBoard("سنگر").hp -= attacker.damage;
                        else
                        {
                            enemy.playerBoard[index-1].hp -= attacker.damage;
                            if (enemy.playerBoard[index-1].hp <= 0)
                            {
                                enemy.playerBoard.Remove(enemy.playerBoard[index-1]);
                            }    
                        }
                        
                    }
                    if (enemy.playerBoard.Count > index+1)
                    {
                        if (trenchExists)
                        {
                            enemy.FindByNameBoard("سنگر").hp -= attacker.damage;
                        }
                        else
                        {
                            enemy.playerBoard[index+1].hp -= attacker.damage;
                            if (enemy.playerBoard[index+1].hp <= 0)
                            {
                                enemy.playerBoard.Remove(enemy.playerBoard[index+1]);
                            }    
                        }
                    }
                    if (trenchExists && enemy.FindByNameBoard("سنگر").hp <= 0)
                        enemy.playerBoard.Remove(enemy.FindByNameBoard("سنگر"));
                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.MachineGun: 
                Debug.Log("Machinegun attack");
                if (trenchExists)
                {
                    enemy.FindByNameBoard("سنگر").hp -= attacker.damage*enemy.playerBoard.Count;
                    if (enemy.FindByNameBoard("سنگر").hp <= 0)
                        enemy.playerBoard.Remove(enemy.FindByNameBoard("سنگر"));
                }
                else
                {
                    for (int i = 0; i < enemy.playerBoard.Count; i++)
                    {
                        enemy.playerBoard[i].hp -= attacker.damage;
                        if (enemy.playerBoard[i].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[i]);
                        }
                    }    
                }
                player.energy -= attacker.energyCost;
                break;
            case CardType.Jet: 
                Debug.Log("Jet attack");
                if (enemy.playerBoard.Count > index)
                {
                    if (trenchExists)
                    {
                        enemy.FindByNameBoard("سنگر").hp -= attacker.damage;
                        if (enemy.FindByNameBoard("سنگر").hp <= 0)
                            enemy.playerBoard.Remove(enemy.FindByNameBoard("سنگر"));
                    }
                    else
                    {
                        enemy.playerBoard[index].hp -= attacker.damage;
                        if (enemy.playerBoard[index].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index]);
                        }
                    }
                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.Trench:
                Debug.Log("trench attack");
                if (enemy.playerBoard.Count > index)
                {
                    if (trenchExists)
                    {
                        enemy.FindByNameBoard("سنگر").hp -= attacker.damage;
                        if (enemy.FindByNameBoard("سنگر").hp <= 0)
                            enemy.playerBoard.Remove(enemy.FindByNameBoard("سنگر"));
                    }
                    else
                    {
                        enemy.playerBoard[index].hp -= attacker.damage;
                        if (enemy.playerBoard[index].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index]);
                        }
                    }
                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.Doctor: 
                Debug.Log("Doctor attack");
                if (enemy.playerBoard.Count > index)
                {
                    if (trenchExists)
                    {
                        enemy.FindByNameBoard("سنگر").hp -= attacker.damage;
                        if (enemy.FindByNameBoard("سنگر").hp <= 0)
                            enemy.playerBoard.Remove(enemy.FindByNameBoard("سنگر"));
                    }
                    else
                    {
                        enemy.playerBoard[index].hp -= attacker.damage;
                        if (enemy.playerBoard[index].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index]);
                        }
                    }
                    player.energy -= attacker.energyCost;
                    for (int i = 0; i < player.playerBoard.Count; i++)
                    {
                        player.playerBoard[i].hp += attacker.damage / 2;
                    }
                }
                
                break;
            case CardType.Engineer: 
                Debug.Log("Engineer attack");
                
                if (enemy.playerBoard.Count > index)
                {
                    if (trenchExists)
                    {
                        enemy.FindByNameBoard("سنگر").hp -= attacker.damage;
                        if (enemy.FindByNameBoard("سنگر").hp <= 0)
                            enemy.playerBoard.Remove(enemy.FindByNameBoard("سنگر"));
                    }
                    else
                    {
                        enemy.playerBoard[index].hp -= attacker.damage;
                        if (enemy.playerBoard[index].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index]);
                        }
                    }
                    player.energy -= attacker.energyCost;
                    for (int i = 0; i < player.playerBoard.Count; i++)
                    {
                        player.playerBoard[i].damage += attacker.damage / 4;
                    }
                }
                break;
            case CardType.Grenade: 
                Debug.Log("Grenade attack");
                enemy.FindByNameBoard(enemyCard.name).hp -= attacker.damage;
                player.energy -= attacker.energyCost;
                player.playerBoard.Remove(attacker);
                break;
            case CardType.DoubleTank: 
                Debug.Log("Double barrel tank attack"); 
                if (enemy.playerBoard.Count > index)
                {
                    if (trenchExists)
                    {
                        enemy.FindByNameBoard("سنگر").hp -= attacker.damage;
                    }
                    else
                    {
                        enemy.playerBoard[index].hp -= attacker.damage;
                        if (enemy.playerBoard[index].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index]);
                        }
                    }
                    if (enemy.playerBoard.Count > index+1)
                    {
                        if (trenchExists)
                        {
                            enemy.FindByNameBoard("سنگر").hp -= attacker.damage;
                        }
                        else
                        {
                            enemy.playerBoard[index+1].hp -= attacker.damage;
                            if (enemy.playerBoard[index+1].hp <= 0)
                            {
                                enemy.playerBoard.Remove(enemy.playerBoard[index+1]);
                            }    
                        }
                    }
                    if (trenchExists && enemy.FindByNameBoard("سنگر").hp <= 0)
                        enemy.playerBoard.Remove(enemy.FindByNameBoard("سنگر"));
                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.RocketLauncher: 
                Debug.Log("Rocket Launcher attack"); 
                enemy.FindByNameBoard(enemyCard.name).hp -= attacker.damage;
                player.energy -= attacker.energyCost;
                break;
            case CardType.RPG: 
                Debug.Log("RPG attack");
                if (enemy.playerBoard.Count > index)
                {
                    if (trenchExists)
                    {
                        enemy.FindByNameBoard("سنگر").hp -= attacker.damage*2;
                        if (enemy.FindByNameBoard("سنگر").hp <= 0)
                            enemy.playerBoard.Remove(enemy.FindByNameBoard("سنگر"));
                    }
                    else
                    {
                        enemy.playerBoard[index].hp -= attacker.damage;
                        if(enemy.playerBoard[index].isFacility)
                            enemy.playerBoard[index].hp -= attacker.damage;
                        if (enemy.playerBoard[index].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index]);
                        }
                    }
                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.Sniper: 
                Debug.Log("Sniper attack");
                if (enemy.playerBoard.Count > index)
                {
                    if (trenchExists)
                    {
                        enemy.FindByNameBoard("سنگر").hp -= attacker.damage*2;
                        if (enemy.FindByNameBoard("سنگر").hp <= 0)
                            enemy.playerBoard.Remove(enemy.FindByNameBoard("سنگر"));
                    }
                    else
                    {
                        enemy.playerBoard[index].hp -= attacker.damage;
                        if(enemy.playerBoard[index].isHuman)
                            enemy.playerBoard[index].hp -= attacker.damage;
                        if (enemy.playerBoard[index].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index]);
                        }
                    }
                    player.energy -= attacker.energyCost;
                }

                break;
            case CardType.Tesla: 
                Debug.Log("Tesla attack");
                for (int i = 0; i < enemy.playerBoard.Count; i++)
                {
                    if (trenchExists)
                    {
                        enemy.FindByNameBoard("سنگر").hp -= attacker.damage/(int)(Math.Pow(2,Math.Abs(index-i)));
                        if (enemy.FindByNameBoard("سنگر").hp <= 0)
                            enemy.playerBoard.Remove(enemy.FindByNameBoard("سنگر"));
                    }
                    enemy.playerBoard[i].hp -= attacker.damage/(int)(Math.Pow(2,Math.Abs(index-i)));
                    if (enemy.playerBoard[i].hp <= 0)
                    {
                        enemy.playerBoard.Remove(enemy.playerBoard[i]);
                    }
                }
                player.energy -= attacker.energyCost;
                break;
            case CardType.ElectricTower:
                Debug.Log("ElectricTower attack");
                break;
            case CardType.Defense:
                Debug.Log("Defense attack");
                break;
            case CardType.AntiAir:
                Debug.Log("AntiAir attack");
                break;
            case CardType.ChemicalBomb:
                Debug.Log("ChemicalBomb attack");
                break;
            case CardType.Radioactive:
                Debug.Log("Radioactive attack");
                break;
            case CardType.Mortar:
                Debug.Log("Mortar attack");
                break;
            case CardType.Microwave:
                Debug.Log("Microwave attack");
                break;
            case CardType.Laser:
                Debug.Log("Laser attack");
                break;
            case CardType.Dolphin:
                Debug.Log("Dolphin attack");
                break;
            case CardType.Dynamite:
                Debug.Log("Dynamite attack");
                break;
            case CardType.Hundred:
                Debug.Log("Hundred attack");
                break;
            case CardType.Submarine:
                Debug.Log("Submarine attack");
                break;
            case CardType.BattleShip:
                Debug.Log("BattleShip attack");
                break;
            case CardType.Hacker:
                Debug.Log("Hacker attack");
                break;
            case CardType.Cowboy:
                Debug.Log("Cowboy attack");
                break;
            case CardType.Firecracker:
                Debug.Log("Firecracker attack");
                break;
            case CardType.Drone:
                Debug.Log("Drone attack");
                break;
            
        }
    }
    public void DrawCard(Player p)
    {
        if (p.playerDeck.Count >= 1 && p.playerHand.Count<5)
        { 
            Card randCard = p.playerDeck[Random.Range(0, p.playerDeck.Count)];
            p.playerDeck.Remove(randCard); 
            p.playerHand.Add(randCard); 
        }
    }

    public void InitializeDeck(Player p)
    {
        for (int i = 0; i < 10; i++)
        {
            int k = Random.Range(0, allCards.Count);
            p.playerDeck.Add(allCards[k]);
        }
    }
    public void InitializeHand(Player p)
    {
        for (int i = 0; i < 5; i++)
        {
            DrawCard(p);
        }
    } 
    private void Update()
    {
        
    }

    private void Start()
    {
        player = new Player();
        InitializeDeck(player);
        InitializeHand(player);
        Debug.Log(player.ToString());
        
        enemy = new Player();
        InitializeDeck(enemy);
        InitializeHand(enemy);

        PlayCard(player.playerHand[1]);
        player.cardPlayed = false;
        PlayCard(player.playerHand[1]);
        Debug.Log(player.playerBoard.Count);
        Debug.Log(player.availableSlots[0]);

    }

    private void ShowCards()
    {
        for (int i = 0; i < 5; i++)
        {
            
            if (i < player.playerBoard.Count)
            {
                Card temp = player.playerBoard[i];
                GameObject spot = blueBoard.transform.GetChild(i).gameObject;
                spot.GetComponent<SpriteRenderer>().sprite = temp.Blueartwork;
            }
            else
            {
                GameObject spot = blueBoard.transform.GetChild(i).gameObject;
                spot.GetComponent<SpriteRenderer>().sprite = null;
            }
            if (i < enemy.playerBoard.Count)
            {
                Card temp = enemy.playerBoard[i];
                GameObject spot = redBoard.transform.GetChild(i).gameObject;
                spot.GetComponent<SpriteRenderer>().sprite = temp.Redartwork;
            }
            else
            {
                GameObject spot = redBoard.transform.GetChild(i).gameObject;
                spot.GetComponent<SpriteRenderer>().sprite = null;
            }
                
        }
    }
}

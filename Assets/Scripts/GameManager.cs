using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Player enemy;
    public List<Card> AllCards = new List<Card>();
    public int turn;

    public bool PlayCard(Card pCard)
    {
        if (player.cardPlayed)
        {
            return false;
        }
        player.cardPlayed = true; 
        player.playerHand.Remove(pCard);
        PlaceCard(pCard);
        return true;
    }

    public void PlaceCard(Card pCard)
    {
        for (int i = player.availableSlots.Length-1;i >= 0; i--)
        {
            if (player.availableSlots[i])
            {
                player.availableSlots[i] = false;
                player.playerBoard.Add(pCard);
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
            case CardType.Terrorist: 
                Debug.Log("Terrorist attack"); 
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
        }
    }
    public void DrawCard(Player p)
    {
        if (p.playerDeck.Count >= 1 && p.playerHand.Count<5)
        { 
            Card randCard = p.playerDeck[Random.Range(0, p.playerDeck.Count)];
            p.playerDeck.Remove(randCard); 
            p.playerHand.Add(randCard); 
            return;
        }
    }

    public void InitializeDeck(Player p)
    {
        for (int i = 0; i < 10; i++)
        {
            int k = Random.Range(0, AllCards.Count);
            p.playerDeck.Add(AllCards[k]);
        }
    }
    public void InitializeHand(Player p)
    {
        for (int i = 0; i < 5; i++)
        {
            DrawCard(p);
            Debug.Log(p.playerHand.Count);
        }
    } 
    private void Update()
    {
        
    }

    private void Start()
    {
        player = new Player();
        InitializeDeck(player);
        Debug.Log(player.ToString());
        InitializeHand(player);
        enemy = new Player();
        InitializeDeck(enemy);
        InitializeHand(enemy);
        
        Debug.Log(player.ToString());
        Debug.Log(enemy.ToString());
        
        
    }
}

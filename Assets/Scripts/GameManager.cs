using System;
using System.Collections.Generic;
using TMPro;
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
    public GameObject blueHand;

    public bool PlayCard(Card pCard)
    {
        Debug.Log(pCard.cardName);
        if (player.cardPlayed)
        {
            return false;
        }

        if (PlaceCard(pCard))
        {
            //player.cardPlayed = true; 
            player.playerHand.Remove(pCard);
        }

        ShowCards();
        ShowHand();
        return true;
    }

    public bool EnemyPlayCard(Card pCard)
    {
        if (enemy.cardPlayed)
        {
            return false;
        }

        if (EnemyPlaceCard(pCard))
        {
            enemy.playerHand.Remove(pCard);
            //enemy.cardPlayed = true;
        }

        ShowCards();
        return true;
    }

    public bool PlaceCard(Card pCard)
    {
        for (int i = 0;i < player.availableSlots.Length; i++)
        {
            if (player.availableSlots[i])
            {
                player.availableSlots[i] = false;
                player.playerBoard.Add(pCard);
                
                return true;
            }
        }

        return false;
    }

    public bool EnemyPlaceCard(Card pCard)
    {
        for (int i = 0;i < enemy.availableSlots.Length; i++)
        {
            if (enemy.availableSlots[i])
            {
                enemy.availableSlots[i] = false;
                enemy.playerBoard.Add(pCard);
                
                return true;
            }
        }

        return false;
    }

    public void Attack(Card attacker,Card enemyCard = null)
    {
        if (player.energy < attacker.energyCost)
        {
            return;
        }
        var trenchExists=enemy.FindByNameBoard("سنگر") != null;
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
            case CardType.Diver:
                Debug.Log(("Diver attack"));
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
        ShowCards();
        EnergyUpdate();
    }
    public void DrawCard(Player p)
    {
        if (p.playerDeck.Count >= 1 && p.playerHand.Count<5)
        { 
            Card randCard = p.playerDeck[Random.Range(0, p.playerDeck.Count)];
            p.playerDeck.Remove(randCard); 
            p.playerHand.Add(randCard);
        }
        ShowHand();
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
        if (turn % 2 == 0)
        {
            if (turn == 2)
                enemy.energy += 1; 
            else if (turn == 4)
                enemy.energy += 3;
            else
                enemy.energy = (enemy.energy + 4 > 10 ? 10:enemy.energy+4);
            DrawCard(enemy);
            EnemyPlayCard(enemy.playerHand[0]);
            turn++;
            if (turn == 3)
                player.energy += 2;
            else if(turn>3)
                player.energy = (player.energy + 4 > 10 ? 10:player.energy+4);
            EnergyUpdate();
        }
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
        ShowCards();
        ShowHand();
        EnergyUpdate();
    }

    private void ShowCards()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < player.playerBoard.Count)
            {
                Card temp = player.playerBoard[i];
                GameObject spot = blueBoard.transform.GetChild(i).gameObject;
                spot.GetComponent<CardAttack>().card = temp;
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
                spot.GetComponent<CardAttack>().card = temp;
                spot.GetComponent<SpriteRenderer>().sprite = temp.Redartwork;
            }
            else
            {
                GameObject spot = redBoard.transform.GetChild(i).gameObject;
                spot.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }

    private void ShowHand()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < player.playerHand.Count)
            {
                Card temp = player.playerHand[i];
                GameObject spot = blueHand.transform.GetChild(i).gameObject;
                spot.GetComponent<PlayCard>().card = temp;
                spot.GetComponent<SpriteRenderer>().sprite = temp.Blueartwork;
                
            }
            else
            {
                GameObject spot = blueHand.transform.GetChild(i).gameObject;
                spot.GetComponent<SpriteRenderer>().sprite = null;
                spot.GetComponent<PlayCard>().card = null;
            }
        }
    }

    public void EnergyUpdate()
    {
        GameObject textObject = GameObject.Find("PlayerEnergyText");
        TextMeshProUGUI textMeshPro = textObject.GetComponent<TextMeshProUGUI>();
        textMeshPro.text = player.energy.ToString();
        textObject = GameObject.Find("EnemyEnergyText");
        textMeshPro = textObject.GetComponent<TextMeshProUGUI>();
        textMeshPro.text = enemy.energy.ToString();
    }
}

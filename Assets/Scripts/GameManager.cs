using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Player enemy;
    public int turn;
    public int turnNumber;

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
        var index=player.playerBoard.IndexOf(attacker);
        switch (attacker.type)
        {
            case CardType.Gunman: 
                Debug.Log("gunman attack");
                if (enemy.playerBoard.Count > index)
                {
                    enemy.playerBoard[index].hp -= attacker.damage;
                    if (enemy.playerBoard[index].hp <= 0)
                    {
                        enemy.playerBoard.Remove(enemy.playerBoard[index]);
                    }

                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.Tank: 
                Debug.Log("Tank attack");
                if (enemy.playerBoard.Count > index)
                {
                    enemy.playerBoard[index].hp -= attacker.damage;
                    if (enemy.playerBoard[index].hp <= 0)
                    {
                        enemy.playerBoard.Remove(enemy.playerBoard[index]);
                    }

                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.Helli: 
                Debug.Log("Hellicopter attack");
                if (enemy.playerBoard.Count > index)
                {
                    enemy.playerBoard[index].hp -= attacker.damage;
                    if (enemy.playerBoard[index].hp <= 0)
                    {
                        enemy.playerBoard.Remove(enemy.playerBoard[index]);
                    }

                    if (index > 0)
                    {
                        enemy.playerBoard[index-1].hp -= attacker.damage;
                        if (enemy.playerBoard[index-1].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index-1]);
                        }
                    }
                    if (enemy.playerBoard.Count > index+1)
                    {
                        enemy.playerBoard[index+1].hp -= attacker.damage;
                        if (enemy.playerBoard[index+1].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index+1]);
                        }
                    }
                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.MachineGun: 
                Debug.Log("Machinegun attack");
                for (int i = 0; i < enemy.playerBoard.Count; i++)
                {
                    enemy.playerBoard[i].hp -= attacker.damage;
                    if (enemy.playerBoard[i].hp <= 0)
                    {
                        enemy.playerBoard.Remove(enemy.playerBoard[i]);
                    }
                }
                player.energy -= attacker.energyCost;
                break;
            case CardType.Jet: 
                Debug.Log("Jet attack");
                if (enemy.playerBoard.Count > index)
                {
                    enemy.playerBoard[index].hp -= attacker.damage;
                    if (enemy.playerBoard[index].hp <= 0)
                    {
                        enemy.playerBoard.Remove(enemy.playerBoard[index]);
                    }

                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.Trench:
                Debug.Log("trench attack");
                if (enemy.playerBoard.Count > index)
                {
                    enemy.playerBoard[index].hp -= attacker.damage;
                    if (enemy.playerBoard[index].hp <= 0)
                    {
                        enemy.playerBoard.Remove(enemy.playerBoard[index]);
                    }

                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.Doctor: 
                Debug.Log("Doctor attack");
                if (enemy.playerBoard.Count > index)
                {
                    enemy.playerBoard[index].hp -= attacker.damage;
                    if (enemy.playerBoard[index].hp <= 0)
                    {
                        enemy.playerBoard.Remove(enemy.playerBoard[index]);
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
                    enemy.playerBoard[index].hp -= attacker.damage;
                    if (enemy.playerBoard[index].hp <= 0)
                    {
                        enemy.playerBoard.Remove(enemy.playerBoard[index]);
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
                enemy.playerBoard.Find(enemyCard).hp -= attacker.damage;
                player.energy -= attacker.energyCost;
                player.playerBoard.Remove(attacker);
                break;
            case CardType.DoubleTank: 
                Debug.Log("Double barrel tank attack"); 
                if (enemy.playerBoard.Count > index)
                {
                    enemy.playerBoard[index].hp -= attacker.damage;
                    if (enemy.playerBoard[index].hp <= 0)
                    {
                        enemy.playerBoard.Remove(enemy.playerBoard[index]);
                    }
                    if (enemy.playerBoard.Count > index+1)
                    {
                        enemy.playerBoard[index+1].hp -= attacker.damage;
                        if (enemy.playerBoard[index+1].hp <= 0)
                        {
                            enemy.playerBoard.Remove(enemy.playerBoard[index+1]);
                        }
                    }
                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.RocketLauncher: 
                Debug.Log("Rocket Launcher attack"); 
                enemy.playerBoard.Find(enemyCard).hp -= attacker.damage;
                player.energy -= attacker.energyCost;
                break;
            case CardType.RPG: 
                Debug.Log("RPG attack");
                if (enemy.playerBoard.Count > index)
                {
                    enemy.playerBoard[index].hp -= attacker.damage;
                    if(enemy.playerBoard[index].isFacility)
                        enemy.playerBoard[index].hp -= attacker.damage;
                    if (enemy.playerBoard[index].hp <= 0)
                    {
                        enemy.playerBoard.Remove(enemy.playerBoard[index]);
                    }
                    player.energy -= attacker.energyCost;
                }
                break;
            case CardType.Sniper: 
                Debug.Log("Sniper attack");
                if (enemy.playerBoard.Count > index)
                {
                    enemy.playerBoard[index].hp -= attacker.damage;
                    if(enemy.playerBoard[index].isHuman)
                        enemy.playerBoard[index].hp -= attacker.damage;
                    if (enemy.playerBoard[index].hp <= 0)
                    {
                        enemy.playerBoard.Remove(enemy.playerBoard[index]);
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
    public void DrawCard()
    {
        if (turn == 1)
        {
            if (player.playerDeck.Count >= 1 || player.playerHand.Count<5)
            {
                Card randCard = player.playerDeck[Random.Range(0, player.playerDeck.Count)];
                player.playerDeck.Remove(randCard);
                player.playerHand.Add(randCard);
                return;
            }
        }
    }

    private void Update()
    {
        for (int i = enemy.playerBoard.Count-1; i >=0 ; i--)
        {
            Card temp = enemy.playerBoard[i];
            
            
        }
    }
}

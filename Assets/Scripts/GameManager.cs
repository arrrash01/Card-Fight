using UnityEngine;

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

    public void Attack(Card attacker,Card enemy = null)
    {
        if (player.energy < attacker.energyCost)
        {
            return;
        }
        else
        {
            switch (attacker.type)
            {
                case CardType.Gunman:
                    Debug.Log("gunman attack");
                    break;
                case CardType.Tank:
                    Debug.Log("Tank attack");
                    break;
                case CardType.Helli:
                    Debug.Log("Hellicopter attack");
                    break;
                case CardType.MachineGun:
                    Debug.Log("Machinegun attack");
                    break;
                case CardType.Jet:
                    Debug.Log("Jet attack");
                    break;
                case CardType.trench:
                    Debug.Log("trench attack");
                    break;
                case CardType.Doctor:
                    Debug.Log("Doctor attack");
                    break;
                case CardType.Engineer:
                    Debug.Log("Engineer attack");
                    break;
                case CardType.Grenade:
                    Debug.Log("Grenade attack");
                    break;
                case CardType.DoubleTank:
                    Debug.Log("Double barrell tank attack");
                    break;
                case CardType.RocketLauncher:
                    Debug.Log("Rocket Launcher attack");
                    break;
                case CardType.RPG:
                    Debug.Log("RPG attack");
                    break;
                case CardType.Sniper:
                    Debug.Log("Sniper attack");
                    break;
                case CardType.Terrorist:
                    Debug.Log("Terrorist attack");
                    break;
                case CardType.Tesla:
                    Debug.Log("Tesla attack");
                    break;
            }
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
    

    
}

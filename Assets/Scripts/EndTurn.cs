using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    public GameManager gm;
    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0))
        {
            if (gm.endGame)
                return;
            if (gm.turn%2==1)
            {
                gm.turn++;
                gm.player.cardPlayed = false;
            }
        }
    }
}

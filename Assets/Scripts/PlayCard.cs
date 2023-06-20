using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCard : MonoBehaviour
{
    public Card card;
    public GameManager gm;
    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<SpriteRenderer>().sprite!=null)
            {
                Debug.Log("clicked");
                gm.PlayCard(card);
            }
        }
    }
}

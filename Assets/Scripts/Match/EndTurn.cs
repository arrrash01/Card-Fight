using UnityEngine;
using UnityEngine.EventSystems;

public class EndTurn : MonoBehaviour, IPointerEnterHandler
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
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
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

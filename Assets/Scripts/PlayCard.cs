
using UnityEngine;
using UnityEngine.EventSystems;

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
    void OnPointerEnter(PointerEventData eventData)
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (GetComponent<SpriteRenderer>().sprite != null)
            {
                Debug.Log("touched");
                gm.PlayCard(card);
            }
        }
    }
}

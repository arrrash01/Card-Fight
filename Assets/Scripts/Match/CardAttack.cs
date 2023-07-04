using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CardAttack : MonoBehaviour, IPointerEnterHandler
{
    public Card card;
    public GameManager gm;
    private ClickManager clickManager;
    private void Start()
    {
        clickManager = FindObjectOfType<ClickManager>();

    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickManager.OnClick(gameObject);
            
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            clickManager.OnClick(gameObject);
        }
    }
    public void CheckAttack()
    {
        
    }
}

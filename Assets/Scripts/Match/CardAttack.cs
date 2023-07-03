using UnityEngine;

public class CardAttack : MonoBehaviour
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

    public void CheckAttack()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameManager gm;
    private GameObject lastClickedObject;
    public void OnClick(GameObject clickedObject)
    {
        if (lastClickedObject != null)
        {
            if (lastClickedObject.tag.Equals("Blue Player") && clickedObject.tag.Equals("Red Player"))
            {
                Debug.Log("attacking");
                gm.Attack(lastClickedObject.GetComponent<CardAttack>().card,clickedObject.GetComponent<CardAttack>().card);
                return;
            }
        }
        lastClickedObject = clickedObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public Card card;

    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;

    public Text energyText;
    public Text damageText;
    public Text healthText;

    // Use this for initialization
    void Start () {
        nameText.text = card.name;
        descriptionText.text = card.description;

        artworkImage.sprite = card.artwork;

        energyText.text = card.energyCost.ToString();
        damageText.text = card.damage.ToString();
        healthText.text = card.hp.ToString();
    }
	
}
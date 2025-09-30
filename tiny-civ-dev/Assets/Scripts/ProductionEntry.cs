using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductionEntry : MonoBehaviour
{
    // Expose text fields for item name, cost, production turns, and icon in the Inspector
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text infoText;
    [SerializeField] Image iconImage;

    public void Setup(string name, string description, int turns, Sprite icon, int cost = 0)
    {
        nameText.text = name;

        // Show turns or cost
        if (turns > 0)
            infoText.text = turns + "turns";
        else
            infoText.text = cost + "gold";

        // Assign icon
        if (iconImage != null)
            iconImage.sprite = icon;
    }  
}

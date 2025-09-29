using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductionEntry : MonoBehaviour
{
    // Expose text fields for item name and cost and production icon in the Inspector
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text infoText;
    [SerializeField] Image iconImage;

    public void Setup(string name, string info, Sprite icon)
    {
        nameText.text = name;
        infoText.text = info;
        iconImage.sprite = icon;
    }  
}

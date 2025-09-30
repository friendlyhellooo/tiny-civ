using UnityEngine;
using UnityEngine.UI;


// (!) Handles switching between Production and Purchase tabs

public class TabController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button productionButton;
    [SerializeField] private Button purchaseButton;

    [Header("Panels")]
    [SerializeField] private GameObject productionPanel;
    [SerializeField] private GameObject purchasePanel;

    void Start()
    {
        productionButton.onClick.AddListener(ShowProduction);
        purchaseButton.onClick.AddListener(ShowPurchase);

        // Start with Production tab active
        ShowProduction();
    }

    private void ShowProduction()
    {
        productionPanel.SetActive(true);
        purchasePanel.SetActive(false);
    }

    private void ShowPurchase()
    {
        productionPanel.SetActive(false);
        purchasePanel.SetActive(true);
    }
}

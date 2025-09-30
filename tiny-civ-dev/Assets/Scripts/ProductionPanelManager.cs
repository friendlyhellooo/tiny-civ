using UnityEngine;
using UnityEngine.UI;

// (!) Manages Production Panel, tabs, item entries (prefabs), and open/close panel behavior
public class ProductionPanelManager : MonoBehaviour
{
    [Header("Panel & Tabs")]
    //Main production panel UI
    [SerializeField] private GameObject panel;
    //Production Tab
    [SerializeField] private GameObject productionPanel;
    //Purchase Tab
    [SerializeField] private GameObject purchasePanel;

    [Header("ScrollView Content")]
    //ScrollView Content Object for Production 
    [SerializeField] private Transform productionContentParent;
    //ScrollView Content Object for Production
    [SerializeField] private Transform purchaseContentParent;

    [Header("Prefabs")]
    // Production Entry Prefab
    [SerializeField] private GameObject entryPrefab;

    [Header("UI Elements")]
    [SerializeField] private Button closeButton;
    [SerializeField] private Button overlayButton;

    private void Awake()
    {
        // (!) Make sure the close buttons are hooked up in inspector

        if (closeButton != null)
            closeButton.onClick.AddListener(ClosePanel);

        if (overlayButton != null)
            overlayButton.onClick.AddListener(ClosePanel);
    }

    // Open/Close Panel
    public void OpenPanel()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    // Clear the ALL o/ entries prefabs in the panel
    public void ClearProductionEntires()
    {
        foreach (Transform child in productionContentParent)
            Destroy(child.gameObject);
    }

    public void ClearPurchaseEntries()
    {
        foreach (Transform child in purchaseContentParent)
            Destroy(child.gameObject);
    }

    // (!) Add entries for each Production and Purchase panel
    public void AddProductionEntry(string name, string description, int turns, Sprite icon, int cost = 0)
    {
        GameObject newEntry = Instantiate(entryPrefab, productionContentParent);
        ProductionEntry entry = newEntry.GetComponent<ProductionEntry>();
        entry.Setup(name, description, turns, icon, cost);
    }

    public void AddPurchaseEntry(string name, string description, int turns, Sprite icon, int cost = 0)
    {
        GameObject newEntry = Instantiate(entryPrefab, purchaseContentParent);
        ProductionEntry entry = newEntry.GetComponent<ProductionEntry>();
        entry.Setup(name, description, turns, icon, cost);
    }
}

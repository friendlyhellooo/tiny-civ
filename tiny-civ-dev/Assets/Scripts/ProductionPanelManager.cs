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

    // Expose building icons in Inspector
    [Header("Icons")]
    [SerializeField] private Sprite sheepIcon;
    [SerializeField] private Sprite mineIcon;
    [SerializeField] private Sprite portIcon;
    [SerializeField] private Sprite marketIcon;
    [SerializeField] private Sprite millIcon;
    [SerializeField] private Sprite wizardTowerIcon;

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
            overlayButton.onClick.AddListener(OnOverlayClick);

        // (!) Hardcoded example entries for testing
        PopulateExampleProductionEntries();
        PopulateExamplePurchaseEntries();
    }

// Leaving this here for now - clean up later
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

    // (!) Hardcoded! ACK FIX LATER Production entries:
    private void PopulateExampleProductionEntries()
    {
        AddProductionEntry("Sheep", "Boosts happiness", 3, sheepIcon);
        AddProductionEntry("Wizard Tower", "Generates culture per turn", 5, wizardTowerIcon);
        AddProductionEntry("Port", "Increase gold count", 4, portIcon);
    }

    // Hardcoded purchase entries
    private void PopulateExamplePurchaseEntries()
    {
        AddPurchaseEntry("Market", "Increase gold output", 0, marketIcon, 100);
        AddPurchaseEntry("Mine", "Increase gold output", 0, mineIcon, 120);
        AddPurchaseEntry("Mill", "Improves Production", 0, millIcon, 150);
    }

    // Close panel w/overlay button
    private void OnOverlayClick()
    {
        // Cast a ray from the camera to where the mouse clicked
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // If the ray hits something
        if (Physics.Raycast(ray, out hit))
        {
            // If the thing we clicked has a BuildingClickHandler, don't close
            if (hit.collider.GetComponent<BuildingClickHandler>() != null)
                return; // clicked a building, do nothing
        }
        // Safe to close panel
        ClosePanel();
    }
    // Open panel - clean this up later
    public void OpenPanel()
    {
        panel.SetActive(true);
    }
}

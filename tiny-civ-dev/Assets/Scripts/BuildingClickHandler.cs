using UnityEngine;

public class BuildingClickHandler : MonoBehaviour
{

    // Reference to the ProductionPanelManager
    [SerializeField] private ProductionPanelManager panelManager; 

    private void OnMouseDown()
    {
        // Just open the Production Panel when this building is clicked
        panelManager.OpenPanel();
    }
}

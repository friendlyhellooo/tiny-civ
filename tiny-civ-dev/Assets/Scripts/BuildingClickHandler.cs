using UnityEngine;

public class BuildingClickHandler : MonoBehaviour
{
    [SerializeField] private ProductionPanelManager panelManager; // Reference to the ProductionPanelManager

    private void OnMouseDown()
    {
        // Just open the Production Panel when this building is clicked
        panelManager.OpenPanel();
    }
}

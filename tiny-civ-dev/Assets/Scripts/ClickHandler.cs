using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] InfoPanelManager panelManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Check for Unit
                UnitRef unit = hit.collider.GetComponent<UnitRef>();
                if (unit != null)
                {
                    panelManager.OpenPanel(
                        unit.data.unitName,
                        unit.data.description,
                        unit.data.icon
                    );
                    return;
                }

                // Check for Building
                BuildingRef building = hit.collider.GetComponent<BuildingRef>();
                if (building != null)
                {
                    panelManager.OpenPanel(
                        building.data.buildingName,
                        building.data.description,
                        building.data.icon
                    );
                    return;
                }
                
                if (panelManager.PanelIsActive())
                {
                    panelManager.ClosePanel();
                    return;
                }
            }
        }
    }
}

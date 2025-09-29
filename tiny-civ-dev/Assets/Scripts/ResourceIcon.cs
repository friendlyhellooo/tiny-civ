using UnityEngine;

public class ResourceIcon : MonoBehaviour
{
    // Expose a couples of text fields in the inspector for resource title and description
    [SerializeField] string tooltipTitle;
    [SerializeField] string tooltipInfo;

    // Ref to tooltip script
    [SerializeField] Tooltip tooltip;

    void OnMouseEnter()
    {
        tooltip.Show(tooltipTitle, tooltipInfo);
    }

    void OnMouseExit()
    {
        tooltip.Hide();     
    }
}

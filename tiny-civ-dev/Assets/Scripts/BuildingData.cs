using UnityEngine;

[CreateAssetMenu(menuName = "Tiny Civ/Building Data")]
public class BuildingData : ScriptableObject
{
    public string buildingName;
    [TextArea] public string description;
    public Sprite icon;
}


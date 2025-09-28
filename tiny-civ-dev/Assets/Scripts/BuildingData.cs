using UnityEngine;

[CreateAssetMenu(menuName = "Tiny Civ/Building Data")]
public class BuildingData : ScriptableObject
{
    public string BuildingName;
    [TextArea] public string yields;
    [TextArea] public string description;
    public Sprite icon;
}


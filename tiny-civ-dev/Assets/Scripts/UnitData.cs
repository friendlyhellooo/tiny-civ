using UnityEngine;

[CreateAssetMenu(menuName = "Tiny Civ/Unit Data")]
public class UnitData : ScriptableObject
{
    public string unitName;
    [TextArea] public string description;
    public Sprite icon;
}

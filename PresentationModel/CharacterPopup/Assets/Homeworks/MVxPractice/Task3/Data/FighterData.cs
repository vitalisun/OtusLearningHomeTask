using UnityEngine;

[CreateAssetMenu(fileName = "FighterData", menuName = "Data/FighterData")]
public class FighterData : ScriptableObject
{
    [SerializeField] private Sprite _Icon;
    [SerializeField] private string _name;

    public Sprite Icon => _Icon;
    public string Name => _name;
}

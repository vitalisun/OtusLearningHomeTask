using UnityEngine;

[CreateAssetMenu(fileName = "ClickerCharacterData", menuName = "Data/ClickerCharacterData")]
public class ClickerCharacterData : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name => _name;
    public int Health = 100;
}
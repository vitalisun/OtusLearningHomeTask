using System;
using UnityEngine;

public class ClickerModel
{
    private ClickerCharacterData[] _characters;

    private int _currentCharacterIndex;

    public event Action OnCharacterChanged;
    public event Action OnDamage;
    public event Action OnLevelFinished;

    public ClickerCharacterData CurrentCharacterData => _characters[_currentCharacterIndex];

    public ClickerModel(ClickerCharacterData[] characters)
    {
        _characters = characters;
    }

    public void Damage(int damage)
    {
        CurrentCharacterData.Health -= damage;

        if (CurrentCharacterData.Health <= 0)
        {
            CurrentCharacterData.Health = 100;
            ChangeCharacter();
        }

        OnDamage?.Invoke();
    }

    private void ChangeCharacter()
    {
        _currentCharacterIndex++;
        if (_currentCharacterIndex >= _characters.Length)
        {
            _currentCharacterIndex = 0;
            OnLevelFinished?.Invoke();
        }

        OnCharacterChanged?.Invoke();
    }
}
using System;
using UnityEngine;

public class ClickerPresenter : IDisposable
{
    private ClickerModel _model;

    public event Action OnCharacterChanged;
    public event Action OnDamage;
    public event Action OnLevelFinished;

    public string CharacterName => _model.CurrentCharacterData.Name;
    public int Health => _model.CurrentCharacterData.Health;

    public ClickerPresenter(ClickerModel model)
    {
        _model = model;
        _model.OnCharacterChanged += OnCharacterChangedHandler;
        _model.OnDamage += OnDamageHandler;
        _model.OnLevelFinished += OnLevelFinishedHandler;
    }

    private void OnLevelFinishedHandler()
    {
        OnLevelFinished?.Invoke();
    }

    private void OnDamageHandler()
    {
        OnDamage?.Invoke();
    }

    private void OnCharacterChangedHandler()
    {
        OnCharacterChanged?.Invoke();
    }

    public void Damage(int randomDamage)
    {
        _model.Damage(randomDamage);
    }

    public void Dispose()
    {
        _model.OnCharacterChanged -= OnCharacterChangedHandler;
        _model.OnDamage -= OnDamageHandler;
        _model.OnLevelFinished -= OnLevelFinishedHandler;
    }
}
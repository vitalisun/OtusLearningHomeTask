using System.Collections;
using System.Collections.Generic;
using Assets.Game.Scripts.Player;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bulletAmountText;
    [SerializeField] private TextMeshProUGUI _healthAmountText;
    [SerializeField] private TextMeshProUGUI _killsAmountText;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.BulletAmount.Subscribe(UpdateBulletAmount);
        _player.Health.Subscribe(UpdateHealthAmount);
    }

    private void OnDisable()
    {
        _player.BulletAmount.Unsubscribe(UpdateBulletAmount);
        _player.Health.Unsubscribe(UpdateHealthAmount);
    }

    private void UpdateBulletAmount(int amount)
    {
        _bulletAmountText.text = amount.ToString();
    }

    private void UpdateHealthAmount(int amount)
    {
        _healthAmountText.text = amount.ToString();
    }


}

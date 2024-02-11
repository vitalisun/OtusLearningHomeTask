using System.Collections;
using System.Collections.Generic;
using Assets.Game.Scripts.GameManager;
using Assets.Game.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bulletAmountText;
    [SerializeField] private TextMeshProUGUI _healthAmountText;
    [SerializeField] private TextMeshProUGUI _killsAmountText;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Player _player;
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        _gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (_gameManager.State == GameState.FINISHED)
        {
            _gameOverPanel.SetActive(true);
        }

        if (_gameManager.State == GameState.PLAYING)
        {
            _gameOverPanel.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestart);


        _player.BulletAmount.Subscribe(UpdateBulletAmount);
        _player.Health.Subscribe(UpdateHealthAmount);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestart);

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

    private void OnRestart()
    {
        Debug.Log("Restart");
        _gameOverPanel.SetActive(false);

        _gameManager.OnStart();
    }
}

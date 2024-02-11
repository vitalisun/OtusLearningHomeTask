using System.Collections;
using System.Collections.Generic;
using Assets.Game.Scripts.GameManager;
using Assets.Game.Scripts.Player;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager.OnStart();
    }

    private void OnEnable()
    {
        _player.DeathEvent.Subscribe(OnPlayerDeath);
    }

    private void OnDisable()
    {
        _player.DeathEvent.Unsubscribe(OnPlayerDeath);
    }

    private void OnPlayerDeath()
    {
        _gameManager.Finish();
    }
}

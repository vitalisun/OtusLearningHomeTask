using System.Collections;
using System.Collections.Generic;
using Assets.Game.Scripts.GameManager;
using Assets.Game.Scripts.Player;
using Assets.Game.Scripts.System;
using UnityEngine;
using Zenject;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private Player _player;
    private InputController _inputController;

    [Inject]
    private void Construct(
        Player player, 
        InputController inputController)
    {
        _player = player;
        _inputController = inputController;
    }

    private void Awake()
    {
        _gameManager.AddListener(_inputController);
    }

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

    private void OnDestroy()
    {
        _gameManager.RemoveListener(_inputController);
    }
}
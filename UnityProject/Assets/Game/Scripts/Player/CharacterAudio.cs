﻿using UnityEngine;

namespace Assets.Game.Scripts.Player
{
    public class CharacterAudio : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private AudioSource _source;

        private void OnEnable()
        {
            _player.FireEvent.Subscribe(PlayFireAudio);
        }

        private void OnDisable()
        {
            _player.FireEvent.Unsubscribe(PlayFireAudio);
        }

        private void PlayFireAudio()
        {
            _source.Play();
        }
    }
}

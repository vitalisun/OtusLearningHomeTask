using UnityEngine;

namespace Assets.Game.Scripts.Player
{
    public class CharacterVfx : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = _player.GetComponentInChildren<ParticleSystem>();
        }

        private void OnEnable()
        {
            _player.FireEvent.Subscribe(PlayFireVfx);
        }

        private void OnDisable()
        {
            _player.FireEvent.Unsubscribe(PlayFireVfx);
        }

        private void PlayFireVfx()
        {
            _particleSystem.Play();
        }
    }
}

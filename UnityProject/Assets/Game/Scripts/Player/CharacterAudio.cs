using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Player
{
    public class CharacterAudio : MonoBehaviour
    {
        private Player _player;
        private AudioSource _source;

        [Inject]
        public void Construct(Player player, AudioSource source)
        {
            _player = player;
            _source = source;
        }

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

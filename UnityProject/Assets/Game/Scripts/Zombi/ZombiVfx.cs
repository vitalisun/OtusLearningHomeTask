using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Scripts.Zombi
{
    public class ZombiVfx : MonoBehaviour
    {
        [SerializeField] private Zombi _zombi;

        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = _zombi.GetComponentInChildren<ParticleSystem>();
        }

        private void OnEnable()
        {
            _zombi.TakeDamageEvent.Subscribe(PlayTakeDamageVfx);
        }

        private void OnDisable()
        {
            _zombi.TakeDamageEvent.Unsubscribe(PlayTakeDamageVfx);
        }

        private void PlayTakeDamageVfx(int damage)
        {
            _particleSystem.Play();
        }
    }
}

using System;
using Assets.Scripts.GameManager;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public sealed class Bullet : MonoBehaviour,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        [NonSerialized] public bool IsPlayer;
        [NonSerialized] public int Damage;

        [SerializeField]
        private new Rigidbody2D _rigidbody2D;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private Vector2 _pausedVelocity;
        private bool _isPaused;

        public void OnPause()
        {
            if (!_isPaused)
            {
                _pausedVelocity = _rigidbody2D.velocity;
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.simulated = false;
                _isPaused = true;
            }
        }

        public void OnResume()
        {
            if (_isPaused)
            {
                _rigidbody2D.velocity = _pausedVelocity;
                _isPaused = false;
                _rigidbody2D.simulated = true;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }

        public void SetVelocity(Vector2 velocity)
        {
            if (_isPaused)
            {
                _pausedVelocity = velocity;
            }
            else
            {
                _rigidbody2D.velocity = velocity;
            }
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }
    }
}
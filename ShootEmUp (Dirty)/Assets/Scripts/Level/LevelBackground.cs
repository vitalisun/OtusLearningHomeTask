using System;
using Assets.Scripts.GameManager.GameSystem.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public sealed class LevelBackground : MonoBehaviour,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFinishListener,
        Listeners.IGameStartListener,
        Listeners.IGameFixedUpdateListener
    {
        private const float InitialPositionY = 0;

        private float _startPositionY;

        private float _endPositionY;

        private float _movingSpeedY;

        private float _positionX;

        private float _positionZ;

        private Transform _myTransform;

        [SerializeField]
        private Params _params;


        [Serializable]
        public sealed class Params
        {
            public float StartPositionY;

            public float EndPositionY;

            public float MovingSpeedY;
        }

        private void Awake()
        {
            enabled = false;

            _startPositionY = _params.StartPositionY;
            _endPositionY = _params.EndPositionY;
            _movingSpeedY = _params.MovingSpeedY;
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (_myTransform.position.y <= _endPositionY)
            {
                _myTransform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _myTransform.position -= new Vector3(
                _positionX,
                _movingSpeedY * Time.fixedDeltaTime,
                _positionZ
            );
        }

        public void OnPause()
        {
            enabled = false;
        }

        public void OnResume()
        {
            enabled = true;
        }

        public void OnFinish()
        {
            enabled = false;
            _myTransform.position = new Vector3(_positionX, InitialPositionY, _positionZ);
        }

        public void OnStart()
        {
            enabled = true;
        }
    }
}
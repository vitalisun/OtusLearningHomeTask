using System;
using System.Collections.Generic;
using Assets.Scripts.GameManager.GameSystem.Interfaces;
using UnityEngine;
using static Assets.Scripts.GameManager.GameSystem.Interfaces.Listeners;

namespace Assets.Scripts.GameManager.GameSystem
{
    public sealed class GameManager : MonoBehaviour
    {
        public GameState State => this._state;

        private GameState _state;

        public event Action OnFinish;

        private List<Listeners.IGameListener> _listeners = new();
        private List<Listeners.IGameUpdateListener> _updateListeners = new();
        private List<Listeners.IGameFixedUpdateListener> _fixedUpdateListeners = new();
        private List<Listeners.IGameLateUpdateListener> _lateUpdateListeners = new();

        private void Awake()
        {
            _state = GameState.OFF;
        }

        private void Update()
        {
            if (_state != GameState.PLAYING) 
                return;

            var deltaTime = Time.deltaTime;
            for (int i = 0; i < _updateListeners.Count; i++)
            {
                var listener = _updateListeners[i];
                listener.OnUpdate(deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (_state != GameState.PLAYING) 
                return;

            var deltaTime = Time.fixedDeltaTime;
            for (int i = 0; i < _fixedUpdateListeners.Count; i++)
            {
                var listener = _fixedUpdateListeners[i];
                listener.OnFixedUpdate(deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (_state != GameState.PLAYING) 
                return;

            var deltaTime = Time.deltaTime;
            for (int i = 0; i < _lateUpdateListeners.Count; i++)
            {
                var listener = _lateUpdateListeners[i];
                listener.OnLateUpdate(deltaTime);
            }
        }

        public void AddListeners(IEnumerable<IGameListener> listeners)
        {
            foreach (var listener in listeners)
            {
                this.AddListener(listener);
            }
        }

        public void AddListener(Listeners.IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }

            _listeners.Add(listener);

            if (listener is Listeners.IGameUpdateListener updateListener)
            {
                _updateListeners.Add(updateListener);
            }

            if (listener is Listeners.IGameFixedUpdateListener fixedUpdateListener)
            {
                _fixedUpdateListeners.Add(fixedUpdateListener);
            }

            if (listener is Listeners.IGameLateUpdateListener lateUpdateListener)
            {
                _lateUpdateListeners.Add(lateUpdateListener);
            }
        }

        public void RemoveListener(IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }

            _listeners.Remove(listener);

            if (listener is IGameUpdateListener updateListener)
            {
                _updateListeners.Remove(updateListener);
            }

            if (listener is IGameFixedUpdateListener fixedUpdateListener)
            {
                _fixedUpdateListeners.Remove(fixedUpdateListener);
            }

            if (listener is IGameLateUpdateListener lateUpdateListener)
            {
                _lateUpdateListeners.Remove(lateUpdateListener);
            }
        }

        public void OnStart()
        {
            foreach (var listener in _listeners)
            {
                if (listener is Listeners.IGameStartListener startListener)
                {
                    startListener.OnStart();
                }
            }

            _state = GameState.PLAYING;
        }

        public void Finish()
        {
            foreach (var listener in _listeners)
            {
                if (listener is Listeners.IGameFinishListener finishListener)
                {
                    finishListener.OnFinish();
                }
            }

            _state = GameState.FINISHED;
            OnFinish?.Invoke();
        }

        public void Pause()
        {
            foreach (var listener in _listeners)
            {
                if (listener is Listeners.IGamePauseListener pauseListener)
                {
                    pauseListener.OnPause();
                }
            }

            _state = GameState.PAUSED;
        }

        public void Resume()
        {
            foreach (var listener in _listeners)
            {
                if (listener is Listeners.IGameResumeListener resumeListener)
                {
                    resumeListener.OnResume();
                }
            }

            _state = GameState.PLAYING;
        }
    }
}
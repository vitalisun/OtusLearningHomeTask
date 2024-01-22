﻿using Lessons.Architecture.PM;
using System;

namespace Assets.Homeworks.PresentationModel.Scripts.CharacterStat
{
    public sealed class CharacterStatPresenter : IDisposable
    {
        private CharacterStatModel _model;

        public string StatText => $"{_model.Name}: {_model.Value}";

        public event Action OnValueChanged;

        public CharacterStatPresenter(CharacterStatModel model)
        {
            _model = model;
            _model.OnValueChanged += OnValueChangedHandler;
        }

        private void OnValueChangedHandler(int newValue)
        {
            OnValueChanged?.Invoke();
        }

        public void ChangeStatValue(int newValue)
        {
            _model.ChangeValue(newValue);
        }

        public void Dispose()
        {
            _model.OnValueChanged -= OnValueChangedHandler;
            _model = null;
        }
    }
}
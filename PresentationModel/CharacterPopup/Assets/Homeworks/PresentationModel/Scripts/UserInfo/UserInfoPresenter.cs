using System;
using Assets.Homeworks.PresentationModel.Scripts;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class UserInfoPresenter : IDisposable
    {
        private UserInfoModel _model;
        public string Name { get; }
        public string Description { get; }
        public Sprite Icon { get; }

        public event Action<string> OnNameChanged;
        public event Action<string> OnDescriptionChanged;
        public event Action<Sprite> OnIconChanged;

        public UserInfoPresenter(UserInfoModel model)
        {
            _model = model;
            Name = _model.Name;
            Description = _model.Description;
            Icon = _model.Icon;

            _model.OnNameChanged += OnNameChangedHandler;
            _model.OnDescriptionChanged += OnDescriptionChangedHandler;
            _model.OnIconChanged += OnIconChangedHandler;
        }

        private void OnNameChangedHandler(string val)
        {
            OnNameChanged?.Invoke(val);
        }

        private void OnDescriptionChangedHandler(string val)
        {
            OnDescriptionChanged?.Invoke(val);
        }

        private void OnIconChangedHandler(Sprite val)
        {
            OnIconChanged?.Invoke(val);
        }

        public void Dispose()
        {
            _model.OnNameChanged -= OnNameChangedHandler;
            _model.OnDescriptionChanged -= OnDescriptionChangedHandler;
            _model.OnIconChanged -= OnIconChangedHandler;

            _model = null;
        }
    }
}
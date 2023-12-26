using System;
using Assets.Homeworks.PresentationModel.Scripts;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class UserInfoPresenter
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Icon { get; }

        public event Action<string> OnNameChanged;
        public event Action<string> OnDescriptionChanged;
        public event Action<Sprite> OnIconChanged;

        public UserInfoPresenter(UserInfoModel model)
        {
            Name = model.Name;
            Description = model.Description;
            Icon = model.Icon;

            model.OnNameChanged += OnNameChangedHandler;
            model.OnDescriptionChanged += OnDescriptionChangedHandler;
            model.OnIconChanged += OnIconChangedHandler;
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
    }
}
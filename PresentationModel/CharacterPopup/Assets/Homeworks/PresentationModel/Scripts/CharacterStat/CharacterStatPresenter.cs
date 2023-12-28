using Lessons.Architecture.PM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Homeworks.PresentationModel.Scripts.CharacterStat
{
    public sealed class CharacterStatPresenter
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
    }
}

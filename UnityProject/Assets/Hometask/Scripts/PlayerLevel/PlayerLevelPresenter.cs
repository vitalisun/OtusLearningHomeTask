using System;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelPresenter : IDisposable
    {
        private PlayerLevelModel _model;
        public string LevelText { get; private set; }
        public string XpText { get; private set; }
        public float SliderValue { get; private set; }


        public event Action OnLevelUp;
        public event Action OnExperienceChanged;


        public PlayerLevelPresenter(PlayerLevelModel model)
        {
            _model = model;
            LevelText = $"Level: {_model.CurrentLevel}";
            XpText = $"XP: {_model.CurrentExperience}/{_model.RequiredExperience}";
            SliderValue = (float)_model.CurrentExperience / _model.RequiredExperience;

            _model.OnExperienceChanged += OnExperienceChangedHandler;
            _model.OnLevelUp += OnLevelUpHandler;
        }

        public void AddExperience(int range)
        {
            _model.AddExperience(range);
        }

        public void LevelUp()
        {
            _model.LevelUp();
        }

        private void OnLevelUpHandler()
        {
            LevelText = $"Level: {_model.CurrentLevel}";
            XpText = $"XP: {_model.CurrentExperience}/{_model.RequiredExperience}";
            SliderValue = (float)_model.CurrentExperience / _model.RequiredExperience;

            OnLevelUp?.Invoke();
        }

        private void OnExperienceChangedHandler(int obj)
        {
            XpText = $"XP: {_model.CurrentExperience}/{_model.RequiredExperience}";
            SliderValue = (float)_model.CurrentExperience / _model.RequiredExperience;

            OnExperienceChanged?.Invoke();
        }

        public void Dispose()
        {
            _model.OnExperienceChanged -= OnExperienceChangedHandler;
            _model.OnLevelUp -= OnLevelUpHandler;

            _model = null;
        }
    }
}
using System;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterInfoPresenter
    {
        private CharacterInfoModel _model;

        public event Action<CharacterStatModel> OnStatAdded;
        public event Action<CharacterStatModel> OnStatRemoved;

        public CharacterInfoPresenter(CharacterInfoModel model)
        {
            _model = model;
            _model.OnStatAdded += StatAddedHandler;
            _model.OnStatRemoved += StatRemovedHandler;
        }

        private void StatAddedHandler(CharacterStatModel stat)
        {
            OnStatAdded?.Invoke(stat);
        }

        private void StatRemovedHandler(CharacterStatModel stat)
        {
            OnStatRemoved?.Invoke(stat);
        }

        public void AddStat(CharacterStatModel stat)
        {
            _model.AddStat(stat);
        }

        public void RemoveStat(CharacterStatModel stat)
        {
            _model.RemoveStat(stat);
        }

        public CharacterStatModel GetStat(string name)
        {
            return _model.GetStat(name);
        }

        public CharacterStatModel[] GetStats()
        {
            return _model.GetStats();
        }
    }
}
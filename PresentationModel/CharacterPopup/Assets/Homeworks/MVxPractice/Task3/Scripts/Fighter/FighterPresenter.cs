using UnityEngine;

namespace Assets.Homeworks.MVxPractice.Task3.Scripts.Fighter
{
    public class FighterPresenter
    {
        private FighterModel _model;

        public string Name => _model.Name;
        public Sprite Icon => _model.Icon;

        public FighterPresenter(FighterModel model)
        {
            _model = model;
        }
    }
}
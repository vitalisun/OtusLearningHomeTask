using UnityEngine;
using Zenject;

namespace Assets.Homeworks.MVxPractice.Task3.Scripts
{
    public class FightingSelectorManager : MonoBehaviour
    {
        private FightingSelectorView _fightingSelectorPrefab;
        private FighterData[] _fighterData;


        private FightingSelectorView _fightingSelectorView;

        [Inject]
        public void Construct(FightingSelectorView fightingSelectorPrefab, FighterData[] fighterData)
        {
            _fightingSelectorPrefab = fightingSelectorPrefab;
            _fighterData = fighterData;
        }

        public void Create()
        {
            _fightingSelectorView = Instantiate(_fightingSelectorPrefab);
            _fightingSelectorView.Init(_fighterData);
        }

        public void Destroy()
        {
            Destroy(_fightingSelectorView.gameObject);
        }
    }
}

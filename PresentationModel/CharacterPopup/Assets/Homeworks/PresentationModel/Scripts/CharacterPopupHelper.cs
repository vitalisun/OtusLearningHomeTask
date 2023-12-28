using System;
using System.Linq;
using Lessons.Architecture.PM;
using UnityEngine;

namespace Assets.Homeworks.PresentationModel.Scripts
{
    public class CharacterPopupHelper : MonoBehaviour
    {
        [SerializeField]
        private UserInfoModelFactory _userInfoModelFactory;

        private CharacterPopup _characterPopup;
        private PlayerLevelPresenter _playerLevelPresenter;
        private UserInfoPresenter _userInfoPresenter;
        private CharacterInfoPresenter _characterInfoPresenter;

        public void ShowPopup()
        {
            _characterPopup = GetComponentInChildren<CharacterPopup>();

            if (_characterPopup == null)
            {
               Debug.Log("CharacterPopup not found");
               return;
            }

            _userInfoPresenter ??= CreateUserInfoPresenter();
            _playerLevelPresenter ??= CreatePlayerLevelPresenter();
            _characterInfoPresenter ??= CreateCharacterInfoPresenter();

            _characterPopup.Show(_userInfoPresenter, _playerLevelPresenter, _characterInfoPresenter);
        }

        public void ResetPopupPresenters()
        {
            _userInfoPresenter = null;
            _playerLevelPresenter = null;
            _characterInfoPresenter = null;
        }

        public void AddExperience(int range)
        {
            if (IsPopupHidden()) 
                return;

            _playerLevelPresenter.AddExperience(range);
        }

        public void AddStat(string name)
        {
            if (IsPopupHidden())
                return;

            var stat = _characterInfoPresenter.GetStat(name);

            if (stat == null)
            {
                stat = new CharacterStatModel(name);
                _characterInfoPresenter.AddStat(stat);
            }
            else
            {
                Debug.Log($"Stat with name {name} already exists");
            }
        }

        public void RemoveStat(string name)
        {
            if (IsPopupHidden())
                return;

            var stats = _characterInfoPresenter.GetStats();
            var stat = stats.FirstOrDefault(s => s.Name?.ToLower() == name.ToLower());

            if (stat != null)
            {
                _characterInfoPresenter.RemoveStat(stat);
            }
            else
            {
                Debug.Log($"Stat with name {name} not found");
            }
        }

        public void ChangeStatValue(string name, int val)
        {
            if (IsPopupHidden())
                return;

            var stats = _characterInfoPresenter.GetStats();
            var stat = stats.FirstOrDefault(s => s.Name?.ToLower() == name.ToLower());

            if (stat != null)
            {
                stat.ChangeValue(val);
            }
            else
            {
                Debug.Log($"Stat with name {name} not found");
            }
        }

        public void AddDefaultStats()
        {
            if (IsPopupHidden())
                return;

            AddStat("Endurance");
            AddStat("Luck");
            AddStat("Magic Power");
            AddStat("Charisma");
            AddStat("Wisdom");
            AddStat("Intelligence");
        }

        public void ClearAllStats()
        {
            if (IsPopupHidden())
                return;

            var stats = _characterInfoPresenter.GetStats().ToList(); // Creating a copy of the stats list

            foreach (var stat in stats)
            {
                _characterInfoPresenter.RemoveStat(stat);
            }
        }

        public void GetAllStats()
        {
            if (IsPopupHidden())
                return;

            var stats = _characterInfoPresenter.GetStats();
            foreach (var stat in stats)
            {
                Debug.Log($"{stat.Name}: {stat.Value}");
            }
        }

        private PlayerLevelPresenter CreatePlayerLevelPresenter()
        {
            var playerLevelModel = new PlayerLevelModel();

            return new PlayerLevelPresenter(playerLevelModel);
        }

        private UserInfoPresenter CreateUserInfoPresenter()
        {
            var userInfoModel = _userInfoModelFactory.CreateUserInfoModel();

            return new UserInfoPresenter(userInfoModel);
        }

        private CharacterInfoPresenter CreateCharacterInfoPresenter()
        {
            var characterInfoModel = new CharacterInfoModel();
            return new CharacterInfoPresenter(characterInfoModel);
        }

        private bool IsPopupHidden()
        {
            if (!_characterPopup.Root.activeSelf)
            {
                Debug.Log("Popup is not active");
                return true;
            }

            return false;
        }
    }
}

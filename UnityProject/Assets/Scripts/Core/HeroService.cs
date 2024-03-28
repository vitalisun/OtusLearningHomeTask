using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class HeroService
    {
        private readonly Dictionary<TeamEnum, List<Hero>> _heroes = new();

        private Hero _targetHero;

        public Hero CurrentHero { get; private set; }

        private TeamEnum _currentTeam;

        private int _currentBlueIdx;
        private int _currentRedIdx;


        public HeroService(List<Hero> redTeamHeroes, List<Hero> blueTeamHeroes)
        {

            _heroes.Add(TeamEnum.Red, redTeamHeroes);
            _heroes.Add(TeamEnum.Blue, blueTeamHeroes);

            _currentTeam = TeamEnum.Red;
            _currentBlueIdx = 0;
            _currentRedIdx = 0;

            CurrentHero = _heroes[_currentTeam].First();

        }

        public Hero SetTarget(Hero hero)
        {
            _targetHero = hero;

            return _targetHero;
        }

        public void DestroyHero(Hero hero)
        {
            if (_heroes[TeamEnum.Red].Contains(hero))
            {
                _heroes[TeamEnum.Red].Remove(hero);
            }
            else if (_heroes[TeamEnum.Blue].Contains(hero))
            {
                _heroes[TeamEnum.Blue].Remove(hero);
            }
        }

        public Hero GetTargetHero(TeamEnum team, int idx)
        {
            return _heroes[team][idx];
        }

        public void NextTurn()
        {
            _currentTeam = _currentTeam == TeamEnum.Red ? TeamEnum.Blue : TeamEnum.Red;

            if(_currentTeam == TeamEnum.Red)
            {
                _currentBlueIdx++;
                if (_currentBlueIdx >= _heroes[TeamEnum.Blue].Count)
                {
                    _currentBlueIdx = 0;
                }

                _currentRedIdx++;
                if (_currentRedIdx >= _heroes[TeamEnum.Red].Count)
                {
                    _currentRedIdx = 0;
                }
            }

            CurrentHero = _currentTeam == TeamEnum.Red ? _heroes[TeamEnum.Red][_currentRedIdx] : _heroes[TeamEnum.Blue][_currentBlueIdx];
        }

        public void DebugLogHeroes()
        {
            Debug.Log("*********    Next turn    *******");

            Debug.Log("Red Team");

            foreach (var hero in _heroes[TeamEnum.Red])
            {
                Debug.Log(hero);
            }

            Debug.Log("Blue Team");

            foreach (var hero in _heroes[TeamEnum.Blue])
            {
                Debug.Log(hero);
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Core;
using Assets.Scripts.Core.Events;
using Assets.Scripts.Core.Handlers;
using Assets.Scripts.Core.Pipeline.Turn;
using UnityEngine;
using Zenject;

namespace UI
{
    public sealed class UIService : MonoBehaviour
    {
        [SerializeField]
        private HeroListView bluePlayer;

        [SerializeField]
        private HeroListView redPlayer;

        private HeroService _heroService;
        private EventBus _eventBus;

        void Awake()
        {

        }

        [Inject]
        private void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;


            var redTeam = new List<Hero>
            {
                HeroData.GetDevourer(),
                HeroData.GetHuntress(),
                HeroData.GetDumbOrc(),
                HeroData.GetVampireLord()
            };

            var blueTeam = new List<Hero>
            {
                HeroData.GetElectro(),
                HeroData.GetFrostMage(),
                HeroData.GetMeditator(),
                HeroData.GetPaladin()
            };

            _heroService = new HeroService(redTeam, blueTeam);

            var attackEventHandler = new AttackEventHandler(eventBus, _heroService);
            _eventBus.Subscribe<AttackEvent>(attackEventHandler.HandleEvent);
        }

        public HeroListView GetBluePlayer()
        {
            return this.bluePlayer;
        }

        public HeroListView GetRedPlayer()
        {
            return this.redPlayer;
        }

        void OnEnable()
        {
            this.bluePlayer.OnHeroClicked += this.OnHeroClicked;
            this.redPlayer.OnHeroClicked += this.OnHeroClicked;
        }

        void OnDisable()
        {
            this.bluePlayer.OnHeroClicked -= this.OnHeroClicked;
            this.redPlayer.OnHeroClicked -= this.OnHeroClicked;
        }

        private void OnHeroClicked(HeroView view)
        {
            // before start pipeline check if right hero was clicked (he can't attack himself or mates)

            var targetTeam = TeamEnum.Blue;
            var heroIdx = bluePlayer.GetViews().ToList().IndexOf(view);

            if (heroIdx == -1)
            {
                heroIdx = redPlayer.GetViews().ToList().IndexOf(view);
                targetTeam = TeamEnum.Red;
            }

            _eventBus.RaiseEvent(new AttackEvent(heroIdx, targetTeam));

            _heroService.NextTurn();
            _heroService.DebugLogHeroes();
        }
    }
}
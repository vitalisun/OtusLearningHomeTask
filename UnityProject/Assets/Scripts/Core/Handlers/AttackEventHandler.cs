using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Core.Events;

namespace Assets.Scripts.Core.Handlers
{
    public class AttackEventHandler : BaseHandler<AttackEvent>
    {
        private HeroService _heroService;
        public AttackEventHandler(EventBus eventBus, HeroService heroService) : base(eventBus)
        {
            _heroService = heroService;
        }

        public override void HandleEvent(AttackEvent evt)
        {
            var currentHero = _heroService.CurrentHero;
            var targetHero = _heroService.GetTargetHero(evt.Team, evt.TargetIdx);


            targetHero.Health -= currentHero.Attack * currentHero.TakeDamageModifier;

            if (targetHero.Health <= 0)
            {
                EventBus.RaiseEvent(new DestroyHeroEvent(targetHero));
            }
        }
    }
}

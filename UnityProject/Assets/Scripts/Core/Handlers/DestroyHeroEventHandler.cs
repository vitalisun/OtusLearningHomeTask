using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Core.Events;

namespace Assets.Scripts.Core.Handlers
{
    public class DestroyHeroEventHandler : BaseHandler<DestroyHeroEvent>
    {
        private HeroService _heroService;

        public DestroyHeroEventHandler(EventBus eventBus, HeroService heroService) : base(eventBus)
        {
            _heroService = heroService;
        }

        public override void HandleEvent(DestroyHeroEvent evt)
        {
            _heroService.DestroyHero(evt.CurrentHero);
        }
    }
}

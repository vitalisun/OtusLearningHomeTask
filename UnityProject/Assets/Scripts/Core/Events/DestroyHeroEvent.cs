using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Events
{
    public readonly struct DestroyHeroEvent : IEvent
    {
        public readonly Hero CurrentHero;

        public DestroyHeroEvent(Hero currentHero)
        {
            CurrentHero = currentHero;
        }
    }
}

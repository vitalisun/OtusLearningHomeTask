using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Events
{
    public readonly struct AttackEvent : IEvent
    {
        public readonly int TargetIdx;
        public readonly TeamEnum Team;

        public AttackEvent(int targetIdx, TeamEnum team)
        {
            TargetIdx = targetIdx;
            Team = team;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Pipeline.Turn.Tasks
{
    public sealed class PlayerTurnTask : Task
    {
        private readonly EventBus _eventBus;


        public PlayerTurnTask(EventBus eventBus)
        {

            _eventBus = eventBus;
        }

   

        private void OnMovePerformed(Vector2Int direction)
        {

            Finish();
        }

        protected override void OnRun()
        {
            throw new NotImplementedException();
        }
    }
}

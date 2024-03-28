using UnityEngine;

namespace Assets.Scripts.Core.Pipeline.Turn.Tasks
{
    public sealed class StartTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Start Turn!");
            
            Finish();
        }
    }
}
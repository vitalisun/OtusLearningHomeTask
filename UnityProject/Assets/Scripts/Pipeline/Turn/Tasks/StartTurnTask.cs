using UnityEngine;

namespace Assets.Scripts.Pipeline.Turn.Tasks
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
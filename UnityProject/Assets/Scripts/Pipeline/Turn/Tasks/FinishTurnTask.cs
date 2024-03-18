using UnityEngine;

namespace Assets.Scripts.Pipeline.Turn.Tasks
{
    public sealed class FinishTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Finish Turn!");
            
            Finish();
        }
    }
}
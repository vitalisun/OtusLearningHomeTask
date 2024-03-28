using System;
using Assets.Scripts.Core.Pipeline.Turn.Tasks;
using JetBrains.Annotations;
using Zenject;

namespace Assets.Scripts.Core.Pipeline.Turn
{
    public sealed class TurnPipelineInstaller : IInitializable, IDisposable
    {
        private TurnPipeline _turnPipeline;

        //[Inject]
        private void Construct(TurnPipeline turnPipeline)
        {
            _turnPipeline = turnPipeline;
        }

        void IInitializable.Initialize()
        {
            _turnPipeline.AddTask(new StartTurnTask());
            _turnPipeline.AddTask(new FinishTurnTask());
        }

        void IDisposable.Dispose()
        {
            _turnPipeline.Clear();
        }
    }
}
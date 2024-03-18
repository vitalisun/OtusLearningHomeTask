using System;
using Assets.Scripts.Pipeline.Turn.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Pipeline.Turn
{
    [UsedImplicitly]
    public sealed class TurnPipelineInstaller : IInitializable, IDisposable
    {
        private TurnPipeline _turnPipeline;

        [Inject]
        private void Construct(TurnPipeline turnPipeline)
        {
            Debug.Log("TurnPipelineInstaller.Construct");

            _turnPipeline = turnPipeline;
        }

        void IInitializable.Initialize()
        {
            Debug.Log("TurnPipelineInstaller.Initialize");

            _turnPipeline.AddTask(new StartTurnTask());
            _turnPipeline.AddTask(new FinishTurnTask());
        }

        void IDisposable.Dispose()
        {
            _turnPipeline.Clear();
        }
    }
}
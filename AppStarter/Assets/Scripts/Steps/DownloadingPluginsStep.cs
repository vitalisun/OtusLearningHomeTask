using Cysharp.Threading.Tasks;
using UnityEngine;

public sealed class DownloadingPluginsStep : StepApplicationRunner
{
    [SerializeField] private StepApplicationRunnerScriptableObject _scriptableObject;
    public override string Title => _scriptableObject.Title;

    public override async UniTask WaitOnCompleted()
    {
        await _scriptableObject.WaitOnCompleted();
    }
}
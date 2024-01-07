using Cysharp.Threading.Tasks;
using UnityEngine;

public sealed class DownloadingServerDataStep : StepApplicationRunner
{
    [SerializeField] private float _waitTime = 3f;
    [SerializeField] private string _title = "Downloading Server Data";

    public override string Title => _title;

    public override async UniTask WaitOnCompleted()
    {
        await UniTask.Delay((int)(_waitTime * 1000));
    }
}
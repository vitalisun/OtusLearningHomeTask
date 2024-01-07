using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(
    fileName = "StepApplicationRunnerScriptableObjectFacebook", 
    menuName = "AppRunner/StepApplicationRunnerScriptableObject")]
public sealed class StepApplicationRunnerScriptableObjectFacebook : StepApplicationRunnerScriptableObject
{
    [SerializeField] private string _title = "Downloading Facebook Data";
    [SerializeField] private float _waitTime = 3f;

    public override string Title => "Facebook";

    public override async UniTask WaitOnCompleted()
    {
        await UniTask.Delay((int)(_waitTime * 1000));
    }
}
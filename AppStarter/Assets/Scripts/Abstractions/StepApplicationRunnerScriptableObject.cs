using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class StepApplicationRunnerScriptableObject : ScriptableObject
{
    public abstract string Title { get; }
    public abstract UniTask WaitOnCompleted();
}
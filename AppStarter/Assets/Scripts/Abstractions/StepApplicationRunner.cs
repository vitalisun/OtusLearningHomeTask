using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class StepApplicationRunner : MonoBehaviour
{
    public abstract string Title { get; }
    public abstract UniTask WaitOnCompleted();
}
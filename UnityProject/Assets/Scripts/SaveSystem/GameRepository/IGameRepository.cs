using System.Collections;
using UnityEngine;

public interface IGameRepository
{
    T GetData<T>();
    bool TryGetData<T>(out T value);
    void SetData<T>(T value);
    void LoadState();
    void SaveState();
}
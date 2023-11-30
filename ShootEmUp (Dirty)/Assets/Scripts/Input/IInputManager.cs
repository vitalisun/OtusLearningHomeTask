using System;

namespace Assets.Scripts.Input
{
    public interface IInputManager
    {
        event Action<bool> OnFireEvent;
        event Action<float> OnMoveEvent;
        void OnUpdate(float deltaTime);
    }
}
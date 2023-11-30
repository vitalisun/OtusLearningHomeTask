namespace Assets.Scripts.GameManager.GameSystem.Interfaces
{
    public sealed class Listeners
    {
        public interface IGameListener
        {
        }

        public interface IGameStartListener : IGameListener
        {
            void OnStart();
        }

        public interface IGameFinishListener : IGameListener
        {
            void OnFinish();
        }

        public interface IGamePauseListener : IGameListener
        {
            void OnPause();
        }

        public interface IGameResumeListener : IGameListener
        {
            void OnResume();
        }

        public interface IGameUpdateListener : IGameListener
        {
            public void OnUpdate(float deltaTime);
        }

        public interface IGameFixedUpdateListener : IGameListener
        {
            void OnFixedUpdate(float deltaTime);
        }

        public interface IGameLateUpdateListener : IGameListener
        {
            void OnLateUpdate(float deltaTime);
        }
    }
}

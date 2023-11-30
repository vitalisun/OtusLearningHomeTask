using Assets.Scripts.GameManager.ServiceLocatorFiles;

namespace Assets.Scripts.GameManager.DI
{
    public interface IInjectProvider
    {
        void Inject(ServiceLocator serviceLocator);
    }
}
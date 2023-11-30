using System.Collections.Generic;
using Assets.Scripts.GameManager.GameSystem.Interfaces;

namespace Assets.Scripts.GameManager.GameSystem.Providers
{
    public interface IGameListenerProvider
    {
        IEnumerable<Listeners.IGameListener> ProvideListeners();
    }
}
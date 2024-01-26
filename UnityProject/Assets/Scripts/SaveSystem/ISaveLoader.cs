using Zenject;

public interface ISaveLoader
{
    public void LoadGame(IGameRepository gameRepository, DiContainer container);
    public void SaveGame(IGameRepository gameRepository, DiContainer container);
}
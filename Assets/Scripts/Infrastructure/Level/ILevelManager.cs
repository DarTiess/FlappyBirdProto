namespace Infrastructure.Level
{
    public interface ILevelManager
    {
        void OnLevelStart();
        void PauseGame();
        void OnPlayGame();
        void OnLevelLost();
    }
}
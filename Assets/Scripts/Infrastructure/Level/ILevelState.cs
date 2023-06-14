namespace Infrastructure.Level
{
    public interface ILevelState
    {
        void OnLevelStart();
        void PauseGame();
        void OnPlayGame();
        void OnLevelLost();
    }
}
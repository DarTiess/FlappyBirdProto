namespace Infrastructure.Level
{
    public interface ILevelContainer
    {
        Level TryGetLevelSettings(int numberLevel);
        int GetMaxLevelValue();
    }
}
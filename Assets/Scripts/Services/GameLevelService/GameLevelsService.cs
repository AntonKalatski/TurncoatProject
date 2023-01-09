namespace Services.GameLevelService
{
    public class GameLevelsService : IGameLevelsService
    {
        private readonly IGameLevelsConfig _levelsConfig;

        public GameLevelsService(IGameLevelsConfig levelsConfig)
        {
            _levelsConfig = levelsConfig;
        }

        public ILevelConfig GetLevelConfig()
        {
            return _levelsConfig.GetLevelConfig();
        }
    }
}
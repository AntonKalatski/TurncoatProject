namespace Services.GameLevelService
{
    public class LevelService : ILevelService
    {
        private readonly IGameLevelsService _gameLevels;

        public LevelService(IGameLevelsService gameLevels)
        {
            _gameLevels = gameLevels;
        }

        public ILevelConfig GetLevelConfig()
        {
            return _gameLevels.GetLevelConfig();
        }
    }
}
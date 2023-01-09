using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Services.GameLevelService
{
    [CreateAssetMenu(fileName = nameof(GameLevelsConfig), menuName = "Configs/Game/" + nameof(GameLevelsConfig))]
    public class GameLevelsConfig : ScriptableObject, IGameLevelsConfig
    {
        [SerializeField] private List<LevelConfig> levelConfigs = new ();
        public ILevelConfig GetLevelConfig() => levelConfigs.First();
    }
}
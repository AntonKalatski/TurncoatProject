using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services.GameLevelService
{
    //todo think about config - as realisation that works with realisations
    [CreateAssetMenu(fileName = nameof(GameLevelsConfig), menuName = "Configs/Game/" + nameof(GameLevelsConfig))]
    public class GameLevelsConfig : ScriptableObject, IGameLevelsConfig
    {
        [SerializeField] private List<LevelConfig> levelConfigs = new List<LevelConfig>();
        public ILevelConfig GetLevelConfig() => levelConfigs.First();
    }
}
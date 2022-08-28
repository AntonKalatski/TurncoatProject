using System.Collections.Generic;
using Services.Realisations.UnitService;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Services.GameLevelService
{
    [CreateAssetMenu(fileName = nameof(LevelConfig), menuName = "Configs/Levels/" + nameof(LevelConfig))]
    public class LevelConfig : SerializedScriptableObject, ILevelConfig
    {
        [OdinSerialize] private Dictionary<UnitType, int> _levelUnits;

        public Dictionary<UnitType, int> LevelUnits => _levelUnits;
    }
}
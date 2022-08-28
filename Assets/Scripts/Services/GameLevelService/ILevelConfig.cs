using System.Collections.Generic;
using Services.Realisations.UnitService;

namespace Services.GameLevelService
{
    public interface ILevelConfig
    {
        Dictionary<UnitType, int> LevelUnits { get; }
    }
}
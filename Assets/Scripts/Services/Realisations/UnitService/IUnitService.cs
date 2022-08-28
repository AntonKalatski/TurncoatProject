using System.Collections.Generic;
using Services.GameLevelService;
using Services.Realisations.Units;

namespace Services.Realisations.UnitService
{
    public interface IUnitService
    {
        HashSet<Unit> Units { get; }
        void CreateLevelUnits(ILevelConfig levelConfig);
    }
}
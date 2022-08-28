using Services.Realisations.Units;
using UnityEngine;

namespace Services.Realisations.UnitService
{
    public class UnitFactory : IUnitFactory
    {
        private readonly IUnitConfig _config;

        public UnitFactory(IUnitConfig config)
        {
            _config = config;
        }

        public Unit CreateUnit(UnitType unitType)
        {
            if (!_config.TryGetUnit(unitType, out var unitPrefab))
            {
                Debug.LogError("There is no such unit in config: {unitType}");
            }

            return Object.Instantiate(unitPrefab);
        }
    }
}
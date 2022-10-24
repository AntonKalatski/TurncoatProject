using Services.Realisations.Units;

namespace Services.Realisations.UnitService
{
    public interface IUnitConfig
    {
        bool TryGetUnit(UnitType type, out Unit unit);
        string GetRandomUnitName();
    }
}
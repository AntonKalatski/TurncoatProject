using Services.Realisations.Units;

namespace Services.Realisations.UnitService
{
    public interface IUnitFactory
    {
        Unit CreateUnit(UnitType type);
    }
}
using Services.GridService;
using Services.Realisations.Units;
using UnityEngine;

namespace Services.LevelGrid
{
    public interface ILevelGridService
    {
        void CreateLevelGrid();
        GridCell GetRandomGridCell();
        bool TryClearUnitAtGridCell(Vector3 pos);
        bool TryGetUnitAtGridCell(Vector3 pos, out Unit unit);
        bool TrySetUnitOnGridCell(Unit unit, Vector3 hitPos, out Vector3 unitPos);
    }
}
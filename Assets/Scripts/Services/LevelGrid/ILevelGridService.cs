using Services.GridService;
using Services.Realisations.Units;
using UnityEngine;

namespace Services.LevelGrid
{
    public interface ILevelGridService
    {
        void CreateLevelGrid();
        bool TrySetUnitOnGridCell(Unit unit, GridCell cell);
        bool TryGetGridCellAtPoint(in Vector3 point, out GridCell cell);
        bool TryGetRandomGridCell(out GridCell cell);
        bool TrySetUnitOnGridCell(Unit unit, out GridCell cell);
        bool TryClearGridCellAtPoint(Vector3 point, out GridCell cell);
        GridPosition GetGridPosition(Vector3 position);
        Vector3 GetWorldPosition(GridPosition gridPosition);
    }
}
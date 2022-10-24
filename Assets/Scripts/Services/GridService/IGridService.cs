using UnityEngine;

namespace Services.GridService
{
    public interface IGridService
    {
        Grid Grid { get; }
        Grid CreateGrid();
        bool TryGetGridCell(Vector3 position, out GridCell cell);
        bool TryGetRandomGridCell(out GridCell cell);
        Vector3 GetWorldPosition(GridPosition gridPosition);
        GridPosition GetGridPosition(Vector3 position);
    }
}
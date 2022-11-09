using System.Collections.Generic;
using Services.GridService;
using Services.Realisations.Units;
using UnityEngine;

namespace Services.LevelGrid
{
    public class LevelGridService : ILevelGridService
    {
        private readonly IGridService _gridService;
        private readonly Dictionary<GridCell, Unit> _levelGridMap = new Dictionary<GridCell, Unit>();

        public LevelGridService(IGridService gridService)
        {
            _gridService = gridService;
        }

        public void CreateLevelGrid()
        {
            _gridService.CreateGrid();
            foreach (var cell in _gridService.Grid.GridCellsMap)
            {
                _levelGridMap.Add(cell.Value, null);
            }
        }

        public bool TrySetUnitOnGridCell(Unit unit, GridCell cell)
        {
            if (!_levelGridMap.ContainsKey(cell))
                return false;
            _levelGridMap[cell] = unit;
            cell.SetUnit(_levelGridMap[cell]);
            return true;
        }

        public bool TryGetGridCellAtPoint(in Vector3 hitPoint, out GridCell cell)
        {
            return _gridService.TryGetGridCell(hitPoint, out cell) && IsGridCellEmpty(cell, out var unit);
        }

        public bool TryGetRandomGridCell(out GridCell cell)
        {
            return _gridService.TryGetRandomGridCell(out cell) && IsGridCellEmpty(cell, out var unit);
        }

        public bool TryClearUnitAtGridCell(GridCell cell)
        {
            if (!_levelGridMap.ContainsKey(cell))
            {
                return false;
            }

            _levelGridMap[cell] = null;
            cell.SetUnit(_levelGridMap[cell]);

            return false;
        }

        public bool TrySetUnitOnGridCell(Unit unit, out GridCell cell)
        {
            if (!_gridService.TryGetGridCell(unit.CurrentPosition, out cell))
            {
                return false;
            }

            if (!IsGridCellEmpty(cell, out var emptyUnit))
            {
                return false;
            }

            _levelGridMap[cell] = unit;
            cell.SetUnit(_levelGridMap[cell]);
            return true;
        }

        public bool TryClearGridCellAtPoint(Vector3 point, out GridCell cell)
        {
            if (!_gridService.TryGetGridCell(point, out cell))
                return false;

            if (!_levelGridMap.ContainsKey(cell))
                return false;

            _levelGridMap[cell] = null;
            cell.SetUnit(_levelGridMap[cell]);

            return true;
        }

        public GridPosition GetGridPosition(Vector3 position)
        {
            return _gridService.GetGridPosition(position);
        }

        public Vector3 GetWorldPosition(GridPosition gridPosition)
        {
            return _gridService.GetWorldPosition(gridPosition);
        }

        private bool IsGridCellEmpty(GridCell gridCell, out Unit unit)
        {
            return !_levelGridMap.TryGetValue(gridCell, out unit) || ReferenceEquals(unit, null);
        }
    }
}
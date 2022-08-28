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
        private GridService.Grid LevelGrid { get; set; }

        public LevelGridService(IGridService gridService)
        {
            _gridService = gridService;
        }

        public void CreateLevelGrid()
        {
            LevelGrid = _gridService.CreateGrid();
        }

        public bool TrySetUnitOnGridCell(Unit unit, Vector3 hitPos, out Vector3 unitPos)
        {
            if (!LevelGrid.TryGetGridCell(hitPos, out var cell))
            {
                unitPos = unit.WorldPosition;
                return false;
            }

            
            _levelGridMap[cell] = unit;
            unitPos = cell.Position.ToVector3();
            cell.SetUnit(_levelGridMap[cell]);
            return true;
        }

        public GridCell GetRandomGridCell() => LevelGrid.GetRandomGridCell();

        public bool TryGetUnitAtGridCell(Vector3 pos, out Unit unit)
        {
            if (LevelGrid.TryGetGridCell(pos, out var cell))
                return _levelGridMap.TryGetValue(cell, out unit);
            unit = null;
            return false;
        }

        public bool TryClearUnitAtGridCell(Vector3 pos)
        {
            if (!LevelGrid.TryGetGridCell(pos, out var cell))
            {
                Debug.Log($"There is no such cell in grid!");
                return false;
            }

            if (!_levelGridMap.ContainsKey(cell))
            {
                Debug.Log($"There is no such cell in grid!");
                return false;
            }

            Debug.Log($"Successfully removed unit: {_levelGridMap[cell]} from cell: {cell}");
            _levelGridMap[cell] = null;
            cell.SetUnit(_levelGridMap[cell]);
            return true;
        }
    }
}
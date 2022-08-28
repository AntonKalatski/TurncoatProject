using System;
using Services.Realisations.Units;
using UnityEngine;

namespace Services.GridService
{
    public class GridCell
    {
        private readonly Grid _grid;

        private Unit Unit { get; set; }

        public GridPosition Position { get; }

        public event Action OnDataChanged;

        public GridCell(Grid grid, GridPosition gridPosition)
        {
            _grid = grid;
            Position = gridPosition;
        }

        public override string ToString() => Position + "\n" + Unit;

        public void SetUnit(Unit unit)
        {
            Unit = unit;
            OnDataChanged?.Invoke();
        }
        public Unit GetUnit()
        {
            return Unit;
        }
    }
}

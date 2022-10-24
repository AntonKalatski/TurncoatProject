using System;
using Services.Realisations.Units;
using UnityEngine;

namespace Services.GridService
{
    public class GridCell
    {
        private readonly Grid _grid;

        public Unit Unit { get; private set; }

        public GridPosition Position { get; }
        public Vector3 WorldPosition { get; }

        public event Action OnDataChanged;

        public GridCell(Grid grid, GridPosition gridPosition, Vector3 worldPosition)
        {
            _grid = grid;
            Position = gridPosition;
            WorldPosition = worldPosition;
        }

        public override string ToString() => $"{Position} \n {Unit}";

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
using Services.LevelGrid;
using Services.Realisations.Units;
using UnityEngine;

namespace Services.Realisations.UnitActions
{
    public class UnitActionService : IUnitActionService
    {
        private readonly ILevelGridService _levelGrid;
        private Unit SelectedUnit { get; set; }

        public UnitActionService(ILevelGridService levelGrid)
        {
            _levelGrid = levelGrid;
        }

        public void HandleUnitSelection(RaycastHit hit)
        {
            if (hit.transform.TryGetComponent<Unit>(out var unit))
                SetSelectedUnit(unit);
        }

        public void HandleUnitMove(RaycastHit hit)
        {
            if (ReferenceEquals(SelectedUnit, null)) return;
            if (!_levelGrid.TrySetUnitOnGridCell(SelectedUnit, hit.point, out Vector3 position)) return;
            SelectedUnit.Move(position);
        }

        public void HandleUnitDeselection()
        {
            SelectedUnit?.Deselect();
            SelectedUnit = null;
        }

        private void SetSelectedUnit(Unit unit)
        {
            if (ReferenceEquals(SelectedUnit, unit))
            {
                return;
            }

            SelectedUnit?.Deselect();
            SelectedUnit = unit;
            SelectedUnit.SetSelected();
        }
    }
}
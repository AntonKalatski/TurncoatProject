using Services.Realisations.Units;
using UnityEngine;

namespace Services.Realisations.UnitActions
{
    public class UnitActionService : IUnitActionService
    {
        public Unit SelectedUnit { get; private set; }

        public void HandleUnitSelection(RaycastHit hit)
        {
            if (hit.transform.TryGetComponent<Unit>(out var unit))
                SetSelectedUnit(unit);
        }

        public void HandleUnitMove(RaycastHit hit)
        {
            if (!ReferenceEquals(SelectedUnit, null))
                SelectedUnit.Move(hit.point);
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
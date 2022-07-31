using UnityEngine;

namespace Services.Realisations.UnitActions
{
    public interface IUnitActionService
    {
        void HandleUnitSelection(RaycastHit hit);
        void HandleUnitMove(RaycastHit hit);
        void HandleUnitDeselection();
    }
}
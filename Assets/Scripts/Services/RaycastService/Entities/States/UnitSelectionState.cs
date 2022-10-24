using Services.RaycastService.Interfaces;
using Services.Realisations.UnitService;
using UnityEngine;

namespace Services.RaycastService.Entities.States
{
    public class UnitSelectionState : IInteractionState
    {
        private readonly IUnitService _unitService;

        public UnitSelectionState(IUnitService unitService)
        {
            _unitService = unitService;
        }

        public void EnterState(ref RaycastHit hit)
        {
            UnitActionHandle(ref hit);
        }

        public void ContinueState(ref RaycastHit hit)
        {
            UnitActionHandle(ref hit);
        }

        public void ExitState()
        {
        }

        private void UnitActionHandle(ref RaycastHit hit)
        {
            _unitService.HandleUnitSelection(ref hit);
        }
    }
}
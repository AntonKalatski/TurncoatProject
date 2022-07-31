using Services.GameInputProvider.Interfaces;
using Services.RaycastService.Interfaces;
using Services.Realisations.UnitActions;
using UnityEngine;

namespace Services.RaycastService.Entities.States
{
    public class UnitsInteractionState : IInteractionState
    {
        private readonly IUnitActionService _unitActionService;

        public UnitsInteractionState(IUnitActionService unitActionService)
        {
            _unitActionService = unitActionService;
        }

        public void EnterState(RaycastHit hit)
        {
            UnitActionHandle(hit);
        }

        public void ContinueState(RaycastHit hit)
        {
            UnitActionHandle(hit);
        }

        public void ExitState()
        {
        }

        private void UnitActionHandle(RaycastHit hit)
        {
            _unitActionService.HandleUnitSelection(hit);
        }
    }
}
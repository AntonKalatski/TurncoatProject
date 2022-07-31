using Services.RaycastService.Interfaces;
using Services.Realisations.UnitActions;
using UnityEngine;

namespace Services.RaycastService.Entities.States
{
    public class GridInteractionState : IInteractionState
    {
        private readonly IUnitActionService _unitActionService;

        public GridInteractionState(IUnitActionService unitActionService)
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

        private void UnitActionHandle(RaycastHit hit)
        {
            _unitActionService.HandleUnitMove(hit);
        }

        public void ExitState()
        {
        }
    }
}
using Services.RaycastService.Interfaces;
using Services.Realisations.UnitService;
using UnityEngine;

namespace Services.RaycastService.Entities.States
{
    public class UnitMoveState : IInteractionState
    {
        private readonly IUnitService _unitService;

        public UnitMoveState(IUnitService unitService)
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

        private void UnitActionHandle(ref RaycastHit hit)
        {
            _unitService.HandleUnitMove(ref hit);
        }

        public void ExitState()
        {
        }
    }
}
using Services.GameInputProvider.Interfaces;
using Services.RaycastService.Interfaces;
using Services.Realisations.UnitActions;
using UnityEngine;

namespace Services.RaycastService.Entities.States
{
    public class DefaultInteractionState : IInteractionState
    {
        private readonly IUnitActionService _unitActionService;

        public DefaultInteractionState(IUnitActionService unitActionService)
        {
            _unitActionService = unitActionService;
        }

        public void EnterState(RaycastHit hit)
        {
            _unitActionService.HandleUnitDeselection();
        }

        public void ContinueState(RaycastHit raycastHit)
        {
        }

        public void ExitState()
        {
        }
    }
}
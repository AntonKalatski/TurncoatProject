using Services.GameInputProvider.Interfaces;
using Services.RaycastService.Interfaces;
using Services.Realisations.UnitService;
using UnityEngine;

namespace Services.RaycastService.Entities.States
{
    public class DefaultInteractionState : IInteractionState
    {
        private readonly IUnitService _unitService;

        public DefaultInteractionState(IUnitService unitService)
        {
            _unitService = unitService;
        }

        public void EnterState(ref RaycastHit hit)
        {
            _unitService.HandleUnitDeselection();
        }

        public void ContinueState(ref RaycastHit raycastHit)
        {
        }

        public void ExitState()
        {
        }
    }
}
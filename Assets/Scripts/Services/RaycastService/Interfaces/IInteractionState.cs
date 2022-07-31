using UnityEngine;

namespace Services.RaycastService.Interfaces
{
    public interface IInteractionState
    {
        void EnterState(RaycastHit hit);
        void ContinueState(RaycastHit hit);
        void ExitState();
    }
}
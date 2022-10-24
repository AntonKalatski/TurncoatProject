using UnityEngine;

namespace Services.RaycastService.Interfaces
{
    public interface IInteractionState
    {
        void EnterState(ref RaycastHit hit);
        void ContinueState(ref RaycastHit hit);
        void ExitState();
    }
}
using Services.GameInputProvider.Entities;
using UnityEngine;

namespace Services.RaycastService.Interfaces
{
    public interface IRaycastService
    {
        void Initialize();
        bool Raycast(in InputArgs args, out RaycastHit hit);
    }
}
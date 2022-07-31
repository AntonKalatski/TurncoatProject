using Services.GameInputProvider.Entities;
using UnityEngine;

namespace Services.RaycastService.Interfaces
{
    public interface IRaycastService
    {
        bool Raycast(in InputArgs args, out RaycastHit hit);
    }
}
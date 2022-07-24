using System;
using Services.GameInputProvider.Entities;

namespace Services.GameInputProvider.Interfaces
{
    public interface IInputProvider
    {
        void AddInputListener(IInputListener listener);
        void RemoveInputListener(IInputListener listener);
    }
}
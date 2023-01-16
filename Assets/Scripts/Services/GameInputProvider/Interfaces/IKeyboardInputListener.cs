using UnityEngine;

namespace Services.GameInputProvider.Interfaces
{
    public interface IKeyboardInputListener
    {
        void OnKeyDown(KeyCode key);
    }
}
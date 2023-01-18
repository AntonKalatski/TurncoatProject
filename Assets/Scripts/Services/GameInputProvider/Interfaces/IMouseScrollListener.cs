using UnityEngine;

namespace Services.GameInputProvider.Interfaces
{
    public interface IMouseScrollListener
    {
        void MouseScroll(Vector2 scroll);
    }
}
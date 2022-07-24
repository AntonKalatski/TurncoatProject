using Services.GameInputProvider.Entities;

namespace Services.GameInputProvider.Interfaces
{
    public interface IInputListener
    {
        void OnMouseButtonDownHandler(InputArgs args);
    }
}
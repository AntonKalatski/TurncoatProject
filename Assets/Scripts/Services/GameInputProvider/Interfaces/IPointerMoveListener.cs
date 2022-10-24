using Services.GameInputProvider.Entities;

namespace Services.GameInputProvider.Interfaces
{
    public interface IPointerMoveListener
    {
        void OnPointerMoveHandler(InputArgs args);
    }
}
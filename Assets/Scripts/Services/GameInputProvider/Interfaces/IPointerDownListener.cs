using Services.GameInputProvider.Entities;

namespace Services.GameInputProvider.Interfaces
{
    public interface IPointerDownListener
    {
        void OnPointerDownHandler(InputArgs args);
    }
}
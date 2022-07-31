namespace Services.GameInputProvider.Interfaces
{
    public interface IInputService
    {
        void AddInputListener(IInputListener listener);
        void RemoveInputListener(IInputListener listener);
    }
}
namespace Services.GameInputProvider.Interfaces
{
    public interface IInputService
    {
        void AddInputListener(IInputListener listener);
        void RemoveInputListener(IInputListener listener);
        void AddPointerDownListener(IPointerDownListener pointerDownListener);
        void RemovePointerDownListener(IPointerDownListener pointerDownListener);
        void AddPointerMoveListener(IPointerMoveListener pointerMoveListener);
        void RemovePointerMoveListener(IPointerMoveListener pointerMoveListener);
        void AddKeyboardListener(IKeyboardInputListener keyboardInputListener);
        void RemoveKeyboardListener(IKeyboardInputListener keyboardInputListener);
    }
}
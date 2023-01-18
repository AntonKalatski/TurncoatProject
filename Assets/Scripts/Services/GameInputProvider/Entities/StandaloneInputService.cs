using System;
using UnityEngine;
using VContainer.Unity;
using Services.GameInputProvider.Interfaces;

namespace Services.GameInputProvider.Entities
{
    public class StandaloneInputService : IInputService, IInitializable, ILateTickable
    {
        private readonly IInputConfig _config;
        private Action<InputArgs> _onPointerDown;
        private Action<InputArgs> _onPointerMove;
        private Action<KeyCode> _onKeyInput;
        private Action<Vector2> _onMouseScrolling;

        private Vector2 _prevPos;
        private Vector2 _currentPos;
        private int[] _values;
        private bool[] _keys;

        public StandaloneInputService(IInputConfig config)
        {
            _config = config;
        }

        public void Initialize()
        {
            _values = (int[]) Enum.GetValues(typeof(KeyCode));
            _keys = new bool[_values.Length];
        }

        public void LateTick()
        {
            _prevPos = _currentPos;
            _currentPos = Input.mousePosition;

            if (!_prevPos.Equals(_currentPos))
            {
                OnMousePositionChanged();
            }

            if (Input.GetMouseButtonDown(0))
            {
                OnMouseButtonDown(0);
            }

            Vector2 mouseScrollDelta = Input.mouseScrollDelta;
            if (mouseScrollDelta.magnitude > 0f)
            {
                OnMouseScrolling(ref mouseScrollDelta);
            }

            if (Input.anyKey)
            {
                foreach (int keyCode in _values)
                {
                    if (!Input.GetKey((KeyCode) keyCode))
                    {
                        continue;
                    }

                    OnKeyInput((KeyCode) keyCode);
                }
            }
        }

        #region InputListener

        public void AddInputListener(IInputListener listener)
        {
            _onPointerDown += listener.OnPointerDownHandler;
            _onPointerMove += listener.OnPointerMoveHandler;
        }

        public void RemoveInputListener(IInputListener listener)
        {
            _onPointerDown -= listener.OnPointerDownHandler;
            _onPointerMove -= listener.OnPointerMoveHandler;
        }

        #endregion

        #region PointerDown

        public void AddPointerDownListener(IPointerDownListener listener)
        {
            _onPointerDown += listener.OnPointerDownHandler;
        }

        public void RemovePointerDownListener(IPointerDownListener listener)
        {
            _onPointerDown -= listener.OnPointerDownHandler;
        }

        #endregion

        #region PointerMove

        public void AddPointerMoveListener(IPointerMoveListener listener)
        {
            _onPointerMove += listener.OnPointerMoveHandler;
        }

        public void RemovePointerMoveListener(IPointerMoveListener listener)
        {
            _onPointerMove -= listener.OnPointerMoveHandler;
        }

        public void AddKeyboardListener(IKeyboardInputListener keyboardInputListener)
        {
            _onKeyInput += keyboardInputListener.OnKeyDown;
        }

        public void RemoveKeyboardListener(IKeyboardInputListener keyboardInputListener)
        {
            _onKeyInput -= keyboardInputListener.OnKeyDown;
        }

        public void AddMouseScrollListener(IMouseScrollListener mouseScrollListener)
        {
            _onMouseScrolling += mouseScrollListener.MouseScroll;
        }

        public void RemoveMouseScrollListener(IMouseScrollListener mouseScrollListener)
        {
            _onMouseScrolling -= mouseScrollListener.MouseScroll;
        }

        private void OnKeyInput(KeyCode keyCode)
        {
            _onKeyInput?.Invoke(keyCode);
        }

        private void OnMouseButtonDown(int pointerId)
        {
            _onPointerDown?.Invoke(new InputArgs(_currentPos, _prevPos, pointerId));
        }

        private void OnMousePositionChanged()
        {
            _onPointerMove?.Invoke(new InputArgs(_currentPos, _prevPos));
        }

        private void OnMouseScrolling(ref Vector2 mouseScrollDelta)
        {
            _onMouseScrolling?.Invoke(mouseScrollDelta);
        }

        #endregion
    }
}
using System;
using Services.GameInputProvider.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Services.GameInputProvider.Entities
{
    public class StandaloneInputService : IInputService, IInitializable, ILateTickable
    {
        private readonly IInputConfig _config;
        private Action<InputArgs> _onPointerDown;
        private Action<InputArgs> _onPointerMove;
        private Action<KeyCode> _onKeyInput;

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

            if (!Input.anyKey)
            {
                return;
            }

            foreach (int keyCode in _values)
            {
                if (!Input.GetKey((KeyCode) keyCode))
                {
                    continue;
                }

                OnKeyInput((KeyCode)keyCode);
            }
        }


        private void OnMouseButtonDown(int pointerId)
        {
            _onPointerDown?.Invoke(new InputArgs(_currentPos, _prevPos, pointerId));
        }

        private void OnMousePositionChanged()
        {
            _onPointerMove?.Invoke(new InputArgs(_currentPos, _prevPos));
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
        
        private void OnKeyInput(KeyCode keyCode)
        {
            _onKeyInput?.Invoke(keyCode);
        }

        #endregion
    }
}
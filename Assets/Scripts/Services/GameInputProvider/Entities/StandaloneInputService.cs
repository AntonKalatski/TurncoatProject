using System;
using Services.GameInputProvider.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Services.GameInputProvider.Entities
{
    public class StandaloneInputService : IInputService, ILateTickable
    {
        private readonly IInputConfig _config;
        private Action<InputArgs> _onPointerDown;
        private Action<InputArgs> _onPointerMove;

        private Vector2 _prevPos;
        private Vector2 _currentPos;

        public StandaloneInputService(IInputConfig config)
        {
            _config = config;
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

        #endregion
    }
}
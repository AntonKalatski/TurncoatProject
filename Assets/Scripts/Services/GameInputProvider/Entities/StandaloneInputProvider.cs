using System;
using Services.GameInputProvider.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Services.GameInputProvider.Entities
{
    public class StandaloneInputProvider : IInputProvider, ILateTickable
    {
        private readonly IInputConfig _config;
        private Action<InputArgs> _onMouseButtonDown;

        private Vector2 prevPos;
        private Vector2 currentPos;

        public StandaloneInputProvider(IInputConfig config)
        {
            _config = config;
        }

        public void LateTick()
        {
            prevPos = currentPos;
            currentPos = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                OnMouseButtonDown();
            }
        }

        private void OnMouseButtonDown()
        {
            var delta = currentPos - prevPos;
            _onMouseButtonDown?.Invoke(new InputArgs(currentPos, delta));
        }

        public void AddInputListener(IInputListener listener)
        {
            _onMouseButtonDown += listener.OnMouseButtonDownHandler;
        }

        public void RemoveInputListener(IInputListener listener)
        {
            _onMouseButtonDown -= listener.OnMouseButtonDownHandler;
        }
    }
}
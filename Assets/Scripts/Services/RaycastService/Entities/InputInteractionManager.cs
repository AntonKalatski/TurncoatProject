using System;
using System.Collections.Generic;
using Services.GameInputProvider.Entities;
using Services.GameInputProvider.Interfaces;
using Services.RaycastService.Interfaces;
using UnityEngine;

namespace Services.RaycastService.Entities
{
    public class InputInteractionManager : IInteractionManager, IPointerDownListener, IDisposable
    {
        private readonly Dictionary<string, IInteractionState> _states = new Dictionary<string, IInteractionState>();
        private readonly IInputService _inputService;
        private readonly IRaycastService _raycastService;
        private readonly IInteractionStateFactory _factory;
        private readonly string[] _layers = new string[7];
        public IInteractionState Current { get; private set; }

        public InputInteractionManager(IInputService inputService,
            IRaycastService raycastService,
            IInteractionStateFactory factory)
        {
            _inputService = inputService;
            _raycastService = raycastService;
            _factory = factory;
        }

        public void Initialize()
        {
            var counter = 0;
            for (var i = 0; i <= _layers.Length; i++)
            {
                var layerName = LayerMask.LayerToName(i);
                if (string.IsNullOrEmpty(layerName)) continue;
                _layers[counter++] = layerName;
            }

            _inputService.AddPointerDownListener(this);
            Debug.Log($"{nameof(InputInteractionManager)} - End of Initialization!");
        }

        public void Dispose()
        {
            _inputService.RemovePointerDownListener(this);
        }

        public void OnPointerDownHandler(InputArgs args)
        {
            if (!_raycastService.Raycast(in args, out RaycastHit hit))
                return;
            var layerId = hit.transform.gameObject.layer;
            if (!TryChangeState(ref hit, layerId))
                return;
            Debug.Log($"{nameof(RaycastService)} Successfully changed to layer {LayerMask.LayerToName(layerId)}");
        }

        private bool TryChangeState(ref RaycastHit hit, int layerId)
        {
            var layerName = LayerMask.LayerToName(layerId);
            if (!_states.TryGetValue(layerName, out var state))
            {
                Debug.LogWarning(
                    $"{nameof(InputInteractionManager)} - There is no such state, creating through factory");
                if (!TryCreateState(layerName, out state))
                {
                    Debug.LogWarning(
                        $"{nameof(InputInteractionManager)} - Factory doesn't has any conditions to create such state");
                    return false;
                }

                _states[layerName] = _factory.Create(layerName);
            }

            if (ReferenceEquals(_states[layerName], Current))
            {
                Debug.Log($"{nameof(InputInteractionManager)} - Same raycast layer, State stays the same!");
                Current?.ContinueState(ref hit);
                return false;
            }

            Current?.ExitState();
            Current = _states[layerName];
            Current.EnterState(ref hit);
            return true;
        }

        private bool TryCreateState(string layerName, out IInteractionState value)
        {
            value = _factory.Create(layerName);
            return !ReferenceEquals(value, null);
        }
    }
}
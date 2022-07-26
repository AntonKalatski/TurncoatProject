using System;
using Services.GameCameraProvider;
using VContainer.Unity;
using Services.GameInputProvider.Entities;
using Services.GameInputProvider.Interfaces;
using UnityEngine;

namespace RayCaster
{
    public class InputRaycaster : IInputRaycaster, IInputListener, IStartable, IDisposable
    {
        private readonly IInputProvider _inputProvider;
        private readonly IRaycastStrategy _raycastStrategy;
        private readonly ICameraService _cameraService;
        private ICameraProvider _cameraProvider;

        public InputRaycaster(IInputProvider inputProvider, ICameraService cameraService)
        {
            _inputProvider = inputProvider;
            _cameraService = cameraService;
        }

        public void Start()
        {
            Debug.Log("InputRaycaster Initialize");
            _inputProvider.AddInputListener(this);
            _cameraProvider = _cameraService.GetCameraProvider(CameraId.Main);
        }

        public void Dispose()
        {
            _inputProvider.RemoveInputListener(this);
        }

        public void OnMouseButtonDownHandler(InputArgs args)
        {
            if (!TryGetLayer(in args, out RaycastHit hit)) return;
            var gameObject = hit.transform.gameObject;
            Debug.Log($"On Mouse button down Pointer:_{args.Pointer} Delta:_{args.Delta} Layer:_{gameObject.layer}");
        }

        private bool TryGetLayer(in InputArgs args, out RaycastHit hit)
        {
            var ray = _cameraProvider.Camera.ScreenPointToRay(args.Pointer);
            return Physics.Raycast(ray, out hit);
        }
    }
}
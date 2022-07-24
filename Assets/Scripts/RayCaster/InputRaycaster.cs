using System;
using Services.GameCameraProvider;
using VContainer.Unity;
using Services.GameInputProvider.Entities;
using Services.GameInputProvider.Interfaces;
using UnityEngine;

namespace RayCaster
{
    public class InputRaycaster : IInputRaycaster, IInitializable, IInputListener,IDisposable 
    {
        private readonly IInputProvider _inputProvider;
        private readonly ICameraService _cameraService;

        public InputRaycaster(IInputProvider inputProvider, ICameraService cameraService)
        {
            _inputProvider = inputProvider;
            _cameraService = cameraService;
        }

        public void Initialize()
        {
             Debug.Log("InputRaycaster Initialize");
            _inputProvider.AddInputListener(this);
            var mainCameraProvider = _cameraService.GetCameraProvider(CameraId.Main);
        }

        public void Dispose()
        {
            _inputProvider.RemoveInputListener(this);
        }

        public void OnMouseButtonDownHandler(InputArgs args)
        {
            Debug.Log($"On Mouse button down Pointer:_{args.Pointer} Delta:_{args.Delta}");
        }
    }
}
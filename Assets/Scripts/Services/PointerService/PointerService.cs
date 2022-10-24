using System;
using UnityEngine;
using VContainer.Unity;
using Object = UnityEngine.Object;
using Providers.GameCameraProvider;
using Services.GameCameraProvider;
using Services.GameInputProvider.Entities;
using Services.GameInputProvider.Interfaces;

namespace Services.PointerService
{
    public class PointerService : IPointerService, IPointerMoveListener, IStartable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly ICameraService _cameraService;

        private readonly PointerServiceConfig _config;

        //fields
        private ICameraProvider _camera;
        private Transform _pointer;
        private Plane _plane;

        public PointerService(IInputService inputService, ICameraService cameraService, PointerServiceConfig config)
        {
            _inputService = inputService;
            _cameraService = cameraService;
            _config = config;
        }

        public void Start()
        {
            _inputService.AddPointerMoveListener(this);
            _camera = _cameraService.GetCameraProvider(CameraId.Main);
            _plane = new Plane(Vector3.up, Vector3.zero);
            var pointerRoot = new GameObject("Debug Pointer Root").transform;
            _pointer = Object.Instantiate(_config.PointerPrefab, Vector3.zero, Quaternion.identity, pointerRoot)
                .transform;
        }

        public void OnPointerMoveHandler(InputArgs args)
        {
            var mousePos = args.Pointer;
            if (_camera.Camera == null)
                return;

            var ray = _camera.Camera.ScreenPointToRay(mousePos);

            if (_plane.Raycast(ray, out var enter))
            {
                _pointer.transform.position = ray.GetPoint(enter);
            }
        }

        public void Dispose()
        {
            _inputService.RemovePointerMoveListener(this);
        }
    }
}
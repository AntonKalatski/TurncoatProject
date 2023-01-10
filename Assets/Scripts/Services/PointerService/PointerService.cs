using System;
using Services.CameraService.Entities;
using UnityEngine;
using VContainer.Unity;
using Services.CameraService.Interfaces;
using Services.GameInputProvider.Entities;
using Services.GameInputProvider.Interfaces;
using Object = UnityEngine.Object;

namespace Services.PointerService
{
    public class PointerService : IPointerService, IPointerMoveListener, IStartable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly ICameraService _cameraService;
        private readonly PointerServiceConfig _config;

        private ICameraProvider<Camera> _camera;
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
            if (!_cameraService.TryGetCameraProvider(CameraId.Camera, out _camera))
            {
                Debug.LogError($"{nameof(PointerService)}: Can't get camera provider");
            }
           
            
            _plane = new Plane(Vector3.up, Vector3.zero);
            Transform pointerRoot = new GameObject("Debug Pointer Root").transform;
            _pointer = Object.Instantiate(_config.PointerPrefab, Vector3.zero, Quaternion.identity, pointerRoot)
                .transform;
        }

        public void OnPointerMoveHandler(InputArgs args)
        {
            Vector2 mousePos = args.Pointer;
            if (_camera.Camera == null)
            {
                return;
            }

            Ray ray = _camera.Camera.ScreenPointToRay(mousePos);

            if (_plane.Raycast(ray, out float enter))
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
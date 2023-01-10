using Services.CameraService.Entities;
using UnityEngine;
using Services.CameraService.Interfaces;
using Services.GameInputProvider.Entities;
using Services.RaycastService.Interfaces;

namespace Services.RaycastService.Entities
{
    public class RaycastService : IRaycastService
    {
        private readonly ICameraService _cameraService;
        private ICameraProvider<Camera> _cameraProvider;

        public RaycastService(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public void Initialize()
        {
            if (!_cameraService.TryGetCameraProvider(CameraId.Camera, out _cameraProvider))
            {
                Debug.LogError($"{nameof(RaycastService)}: Can't get camera provider");
            }
        }

        public bool Raycast(in InputArgs args, out RaycastHit hit)
        {
            var ray = _cameraProvider.Camera.ScreenPointToRay(args.Pointer);
            return Physics.Raycast(ray, out hit);
        }
    }
}
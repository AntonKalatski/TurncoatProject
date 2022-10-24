using UnityEngine;
using Providers.GameCameraProvider;
using Services.GameCameraProvider;
using Services.GameInputProvider.Entities;
using Services.RaycastService.Interfaces;

namespace Services.RaycastService.Entities
{
    public class RaycastService : IRaycastService
    {
        private readonly ICameraService _cameraService;
        private ICameraProvider CameraProvider { get; set; }

        public RaycastService(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public void Initialize()
        {
            CameraProvider = _cameraService.GetCameraProvider(CameraId.Main);
        }

        public bool Raycast(in InputArgs args, out RaycastHit hit)
        {
            var ray = CameraProvider.Camera.ScreenPointToRay(args.Pointer);
            return Physics.Raycast(ray, out hit);
        }
    }
}
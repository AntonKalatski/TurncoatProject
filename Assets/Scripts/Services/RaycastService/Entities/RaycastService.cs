using System;
using Providers.GameCameraProvider;
using Services.GameCameraProvider;
using Services.GameInputProvider.Entities;
using Services.RaycastService.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Services.RaycastService.Entities
{
    public class RaycastService : IRaycastService, IStartable
    {
        private readonly ICameraService _cameraService;
        private ICameraProvider _cameraProvider;

        public RaycastService(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public void Start()
        {
            _cameraProvider = _cameraService.GetCameraProvider(CameraId.Main);
        }
        public bool Raycast(in InputArgs args, out RaycastHit hit)
        {
            var ray = _cameraProvider.Camera.ScreenPointToRay(args.Pointer);
            return Physics.Raycast(ray, out hit);
        }
    }
}
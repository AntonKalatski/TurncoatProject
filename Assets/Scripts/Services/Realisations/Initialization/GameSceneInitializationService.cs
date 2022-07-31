using Services.GameCameraProvider;
using Services.RaycastService.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Services.Realisations.Initialization
{
    public class GameSceneInitializationService : IInitializable
    {
        private readonly IRaycastService _raycastService;
        private readonly ICameraService _cameraService;

        public GameSceneInitializationService(IRaycastService raycastService, ICameraService cameraService)
        {
            _raycastService = raycastService;
            _cameraService = cameraService;
        }

        public void Initialize()
        {
            Debug.Log("Initialize in InitializationService");
        }
    }
}
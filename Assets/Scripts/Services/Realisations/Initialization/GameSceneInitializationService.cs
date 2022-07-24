using RayCaster;
using Services.GameCameraProvider;
using UnityEngine;
using VContainer.Unity;

namespace Services.Realisations.Initialization
{
    public class GameSceneInitializationService : IInitializable
    {
        private readonly IInputRaycaster _raycaster;
        private readonly ICameraService _cameraService;

        public GameSceneInitializationService(IInputRaycaster raycaster, ICameraService cameraService)
        {
            _cameraService = cameraService;
            _raycaster = raycaster;
            Debug.Log("InitializationService ctor");
        }

        public void Initialize()
        {
            var main = _cameraService.GetCameraProvider(CameraId.Main);
            var cutscene = _cameraService.GetCameraProvider(CameraId.Cutscene);
            Debug.Log("Initialize in InitializationService");
        }
    }
}
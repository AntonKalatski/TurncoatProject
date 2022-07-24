using UnityEngine;
using VContainer;

namespace Services.GameCameraProvider
{
    public class CameraProvider : MonoBehaviour, ICameraProvider
    {
        [SerializeField] private Camera gameCamera;
        [SerializeField] private CameraArgs cameraArgs;
        private ICameraService _cameraService;
        
        public Transform Transform => transform;
        public Camera Camera => gameCamera;
        public CameraArgs CameraArgs => cameraArgs;

        [Inject]
        public void Construct(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        private void Awake()
        {
            _cameraService.AddCameraProvider(this);
        }
    }
}
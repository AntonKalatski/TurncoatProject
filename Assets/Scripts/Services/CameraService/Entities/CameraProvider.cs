using VContainer;
using UnityEngine;
using Services.GameCameraProvider;

namespace Services.CameraService.Entities
{
    public class CameraProvider : MonoBehaviour, ICameraProvider
    {
        [SerializeField] private Camera gameCamera;
        [SerializeField] private CameraArgs cameraArgs;
        
        public Transform Transform => transform;
        public Camera Camera => gameCamera;
        public CameraArgs CameraArgs => cameraArgs;

        [Inject]
        public void Construct(ICameraService cameraService)
        {
            cameraService.AddCameraProvider(this);
        }
    }
}
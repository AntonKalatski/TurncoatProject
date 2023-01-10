using Services.CameraService.Interfaces;
using VContainer;
using UnityEngine;
using Services.GameCameraProvider;

namespace Services.CameraService.Entities
{
    public abstract class CameraProvider<TCamera> : MonoBehaviour, ICameraProvider<TCamera>
    {
        [SerializeField] private TCamera gameCamera;
        [SerializeField] private CameraArgs cameraArgs;
        public TCamera Camera => gameCamera;
        public CameraArgs CameraArgs => cameraArgs;

        [Inject]
        public void Construct(ICameraService cameraService)
        {
            cameraService.AddCameraProvider(this);
        }
    }
}
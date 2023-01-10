using Services.CameraService.Entities;

namespace Services.CameraService.Interfaces
{
    public interface ICameraService
    {
        void AddCameraProvider<TCamera>(ICameraProvider<TCamera> cameraProvider);
        void RemoveCameraProvider<TCamera>(ICameraProvider<TCamera> cameraProvider);
        bool TryGetCameraProvider<TCamera>(CameraId id, out ICameraProvider<TCamera> provider);
    }
}
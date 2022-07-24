namespace Services.GameCameraProvider
{
    public interface ICameraService
    {
        void AddCameraProvider(ICameraProvider cameraProvider);
        void RemoveCameraProvider(ICameraProvider cameraProvider);
        ICameraProvider GetCameraProvider(CameraId id);
    }
}
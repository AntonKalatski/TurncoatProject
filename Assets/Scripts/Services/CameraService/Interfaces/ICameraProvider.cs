using Services.GameCameraProvider;

namespace Services.CameraService.Interfaces
{
    public interface ICameraProvider
    {
        CameraArgs CameraArgs { get; }
    }

    public interface ICameraProvider<out TCamera> : ICameraProvider
    {
        TCamera Camera { get; }
    }
}
using UnityEngine;

namespace Services.GameCameraProvider
{
    public interface ICameraProvider
    {
        Transform Transform { get; }
        Camera Camera { get; }
        CameraArgs CameraArgs { get; }
    }
}
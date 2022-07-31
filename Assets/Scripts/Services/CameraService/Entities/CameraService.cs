using System.Collections.Generic;
using Providers.GameCameraProvider;
using UnityEngine;

namespace Services.GameCameraProvider
{
    public class CameraService : ICameraService
    {
        private readonly Dictionary<CameraId, ICameraProvider>
            _cameraProviders = new Dictionary<CameraId, ICameraProvider>();

        public ICameraProvider GetCameraProvider(CameraId id)
        {
            if (_cameraProviders.TryGetValue(id, out var provider)) return provider;
            Debug.Log("There is no such camera provider");
            return null;
        }

        public void AddCameraProvider(ICameraProvider provider)
        {
            if (_cameraProviders.ContainsKey(provider.CameraArgs.cameraId)) return;
            Debug.Log("Camera provider registered");
            _cameraProviders.Add(provider.CameraArgs.cameraId, provider);
        }

        public void RemoveCameraProvider(ICameraProvider provider)
        {
            if (!_cameraProviders.TryGetValue(provider.CameraArgs.cameraId, out var result))
                return;
            Debug.Log("Camera provider removed");
            _cameraProviders.Remove(provider.CameraArgs.cameraId);
        }
    }
}
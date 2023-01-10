using UnityEngine;
using System.Collections.Generic;
using Services.CameraService.Interfaces;

namespace Services.CameraService.Entities
{
    public class CameraService : ICameraService
    {
        private readonly Dictionary<CameraId, ICameraProvider>
            _cameraProviders = new Dictionary<CameraId, ICameraProvider>();

        public bool TryGetCameraProvider<TCamera>(CameraId id, out ICameraProvider<TCamera> provider)
        {
            provider = null;
            if (_cameraProviders.TryGetValue(id, out ICameraProvider cameraProvider))
            {
                return !ReferenceEquals(provider = cameraProvider as ICameraProvider<TCamera>, null);
            }

            Debug.Log("There is no such camera provider");
            return false;
        }

        public void AddCameraProvider<TCamera>(ICameraProvider<TCamera> provider)
        {
            if (_cameraProviders.ContainsKey(provider.CameraArgs.cameraId)) return;
            Debug.Log("Camera provider registered");
            _cameraProviders.Add(provider.CameraArgs.cameraId, provider);
        }

        public void RemoveCameraProvider<TCamera>(ICameraProvider<TCamera> provider)
        {
            if (!_cameraProviders.TryGetValue(provider.CameraArgs.cameraId, out ICameraProvider result))
                return;
            Debug.Log("Camera provider removed");
            _cameraProviders.Remove(provider.CameraArgs.cameraId);
        }
    }
}
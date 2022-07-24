using RayCaster;
using Services.GameCameraProvider;
using Services.Realisations.Initialization;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes.Initialization
{
    public class GameSceneScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("InitializationSceneScope Configure");
            builder.RegisterEntryPoint<GameSceneInitializationService>();
            builder.Register<InputRaycaster>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CameraService>(Lifetime.Singleton).As<ICameraService>();
        }
    }
}
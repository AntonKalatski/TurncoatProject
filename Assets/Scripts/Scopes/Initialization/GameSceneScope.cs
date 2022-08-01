using Services.GameCameraProvider;
using Services.Grid;
using Services.RaycastService.Entities;
using Services.RaycastService.Entities.Factory;
using Services.RaycastService.Interfaces;
using Services.Realisations.Initialization;
using Services.Realisations.UnitActions;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes.Initialization
{
    public class GameSceneScope : LifetimeScope
    {
        [SerializeField] private GridConfig gridConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("InitializationSceneScope Configure");
            builder.RegisterEntryPoint<GameSceneInitializationService>();
            builder.RegisterEntryPoint<GridService>();
            builder.RegisterInstance(gridConfig);
            builder.Register<UnitActionService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<RaycastService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<InputInteractionManager>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CameraService>(Lifetime.Singleton).As<ICameraService>();
            builder.Register<RaycastStateFactory>(Lifetime.Singleton).As<IInteractionStateFactory>();
        }
    }
}
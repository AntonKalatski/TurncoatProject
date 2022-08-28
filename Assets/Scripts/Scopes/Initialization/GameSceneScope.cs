using Services.CameraService.Entities;
using Services.GameLevelService;
using Services.GridService;
using Services.LevelGrid;
using Services.RaycastService.Entities;
using Services.RaycastService.Entities.Factory;
using Services.Realisations.Initialization;
using Services.Realisations.UnitActions;
using Services.Realisations.UnitService;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes.Initialization
{
    public class GameSceneScope : LifetimeScope
    {
        [SerializeField] private GridConfig gridConfig;
        [SerializeField] private UnitConfig unitConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("InitializationSceneScope Configure");
            builder.RegisterEntryPoint<GameSceneBootstrapper>();


            BindLevelServices(builder);
            BindConfigs(builder);
            BindInputService(builder);
            BindRaycastService(builder);
            BindCameraServices(builder);
            BindUnitServices(builder);
            BindGridServices(builder);
        }

        private void BindLevelServices(IContainerBuilder builder)
        {
            builder.Register<LevelService>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void BindConfigs(IContainerBuilder builder)
        {
            builder.RegisterInstance(gridConfig);
            builder.RegisterInstance(unitConfig).AsImplementedInterfaces().AsSelf();
        }

        private static void BindInputService(IContainerBuilder builder)
        {
            builder.Register<InputInteractionManager>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private static void BindRaycastService(IContainerBuilder builder)
        {
            builder.Register<RaycastService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<RaycastStateFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void BindCameraServices(IContainerBuilder builder)
        {
            builder.Register<CameraService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<CameraProvider>().AsImplementedInterfaces();
        }

        private void BindGridServices(IContainerBuilder builder)
        {
            builder.Register<GridService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<LevelGridService>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void BindUnitServices(IContainerBuilder builder)
        {
            builder.Register<UnitData>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<UnitService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<UnitFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<UnitActionService>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
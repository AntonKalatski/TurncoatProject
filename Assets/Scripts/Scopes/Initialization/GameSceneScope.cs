using Game.Controllers.GameCamera;
using Services.CameraService.Entities;
using Services.GameLevelService;
using Services.GridService;
using Services.LevelGrid;
using Services.PointerService;
using Services.RaycastService.Entities;
using Services.RaycastService.Entities.Factory;
using Services.Realisations.Initialization;
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
        [SerializeField] private PointerServiceConfig pointerServiceConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("InitializationSceneScope Configure");
            builder.Register<GameSceneBootstrapper>(Lifetime.Singleton).AsImplementedInterfaces().Build();

            BindConfigs(builder);
            BindLevelServices(builder);
            BindCameraServices(builder);
            BindInputService(builder);
            BindPointerService(builder);
            BindRaycastService(builder);
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
            builder.RegisterInstance(pointerServiceConfig);
            builder.RegisterInstance(unitConfig).AsImplementedInterfaces().AsSelf();
        }

        private static void BindInputService(IContainerBuilder builder)
        {
            builder.Register<InputInteractionManager>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void BindPointerService(IContainerBuilder builder)
        {
            builder.Register<PointerService>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private static void BindRaycastService(IContainerBuilder builder)
        {
            builder.Register<RaycastService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<RaycastStateFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void BindCameraServices(IContainerBuilder builder)
        {
            builder.Register<CameraService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CameraController>(Lifetime.Singleton).AsImplementedInterfaces().Build();
            builder.RegisterComponentInHierarchy<CinemachineCameraProvider>();
            builder.RegisterComponentInHierarchy<UnityCameraProvider>();
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
            // builder.Register<UnitActionService>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
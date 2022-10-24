using Services.GameInputProvider.Entities;
using Services.GameInputProvider.Interfaces;
using Services.GameLevelService;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes.Game
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameLevelsConfig gameLevels;
        [SerializeField] private InputConfig gameInputConfig;
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterGameLevels(builder);
            RegisterInputProvider(builder);
        }

        private void RegisterGameLevels(IContainerBuilder builder)
        {
            builder.RegisterInstance(gameLevels).As<IGameLevelsConfig>().AsSelf();
            builder.Register<GameLevelsService>(Lifetime.Singleton).AsImplementedInterfaces().Build();
        }

        private void RegisterInputProvider(IContainerBuilder builder)
        {
            builder.RegisterInstance(gameInputConfig).As<IInputConfig>();
            builder.RegisterEntryPoint<StandaloneInputService>().As<IInputService>();
        }
    }
}
using Configs.Test;
using Services.GameInputProvider.Entities;
using Services.GameInputProvider.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes.Game
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        [SerializeField] private InputConfig _gameInputConfig;
        [SerializeField] private TestConfig _config;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<StandaloneInputProvider>().As<IInputProvider>();
            Debug.Log("GameLifetimeScope Configure");
            RegisterIntances(builder);
        }

        private void RegisterIntances(IContainerBuilder builder)
        {
            builder.RegisterInstance(_config);
            builder.RegisterInstance(_gameInputConfig).As<IInputConfig>();
        }
    }
}
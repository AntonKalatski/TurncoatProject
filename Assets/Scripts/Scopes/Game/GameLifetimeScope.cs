using Configs.Test;
using Services.Advertisement;
using Services.Input;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private TestConfig _config;
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("GameLifetimeScope Configure");
            builder.Register<IInputService,InputService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<AdsService>();
            builder.RegisterInstance(_config);
        }
    }
}
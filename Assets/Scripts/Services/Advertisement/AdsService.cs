using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace Services.Advertisement
{
    public class AdsService : IAdsService, IAsyncStartable
    {
        public bool IsInitialized { get; private set; } = false;

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            Debug.Log(nameof(AdsService)+ "Starting initializing");
            await UniTask.Delay(3000);
            Debug.Log(nameof(AdsService)+ "Initialized");
            IsInitialized = true;
        }
    }
}
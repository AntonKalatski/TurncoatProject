using Cysharp.Threading.Tasks;
using Services.Advertisement;
using Services.GameInput;
using UnityEngine;
using VContainer.Unity;

namespace Services.Initialization
{
    public class InitializationService : IInitializable
    {
        private readonly IInputService _inputService;
        private readonly IAdsService _adsService;

        public InitializationService(IInputService inputService, IAdsService adsService)
        {
            Debug.Log("InitializationService ctor");
            _inputService = inputService;
            _adsService = adsService;
        }

        public void Initialize()
        {
            Debug.Log("Initialize in InitializationService");
            _inputService.Initialize();
            if (!_adsService.IsInitialized)
            {
                Debug.Log("_adsService.IsInitialized is not initialize");
                StartAwaiting().Forget();
            }
        }

        private async UniTaskVoid StartAwaiting()
        {
            Debug.Log("StartAwaiting");
            await UniTask.WaitWhile(() => !_adsService.IsInitialized);
            Debug.Log("Ads service initialized");
        }
    }
}
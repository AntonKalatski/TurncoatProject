using Configs.Test;
using Services.GameInputProvider.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Services.Realisations.GameInput
{
    public class InputService : IInputService, ITickable
    {
        private readonly TestConfig _testConfig;

        public InputService(TestConfig testConfig)
        {
            _testConfig = testConfig;
        }
        public void Initialize()
        {
            Debug.Log("Input Service initialized");
            Debug.Log($"Input Service Test Config SomeFloat {_testConfig.SomeFloat}");
            Debug.Log($"Input Service Test Config SomeString{_testConfig.SomeString}");
            Debug.Log($"Input Service Test Config SomeStruct {_testConfig.SomeStruct}");
        }

        public void Tick()
        {
            Debug.Log("Input Service Tick");
        }
    }
}
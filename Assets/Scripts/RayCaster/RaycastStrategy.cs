using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace RayCaster
{
    public class RaycastStrategy : IRaycastStrategy, IInitializable
    {
        private readonly IRaycastBehaviourFactory _factory;
        private readonly string[] _layers = new string[31];
        private Dictionary<string, IRaycastBehaviour> _strategies;

        public RaycastStrategy(IRaycastBehaviourFactory factory)
        {
            _factory = factory;
        }

        public void Initialize()
        {
            var counter = 0;
            for (var i = 0; i <= 31; i++) //user defined layers start with layer 8 and unity supports 31 layers
            {
                var layerName = LayerMask.LayerToName(i); //get the name of the layer
                if (string.IsNullOrEmpty(layerName)) continue;
                _layers[counter++] = layerName;
            }

            Debug.Log("End of initialize");
            var test = _factory.Create("test");
            test.Cast();
        }
    }
}
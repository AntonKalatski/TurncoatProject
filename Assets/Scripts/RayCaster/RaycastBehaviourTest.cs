using Services.GameInputProvider.Interfaces;
using UnityEngine;

namespace RayCaster
{
    public class RaycastBehaviourTest : IRaycastBehaviour
    {
        private readonly IInputProvider _provider;

        public RaycastBehaviourTest(IInputProvider provider)
        {
            _provider = provider;
        }
        public void Cast()
        {
            Debug.Log("RaycastBehaviourTest CAST!!!");
            if (!ReferenceEquals(_provider, null))
            {
                Debug.Log("PROVIDER NOT NULL CAST!!!");
            }
        }
    }
}
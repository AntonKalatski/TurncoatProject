using Services.GameInputProvider.Interfaces;
using VContainer;

namespace RayCaster
{
    public class RaycastBehaviourFactory : IRaycastBehaviourFactory
    {
        private readonly IObjectResolver _resolver;

        public RaycastBehaviourFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public IRaycastBehaviour Create(string value)
        {
            var dependency = _resolver.Resolve<IInputProvider>();
            IRaycastBehaviour test = new RaycastBehaviourTest(dependency);
            return test;
        }
    }
}
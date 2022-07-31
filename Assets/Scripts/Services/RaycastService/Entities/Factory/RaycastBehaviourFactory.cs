using Services.RaycastService.Entities.States;
using Services.RaycastService.Interfaces;
using Services.Realisations.UnitActions;
using VContainer;

namespace Services.RaycastService.Entities.Factory
{
    public class RaycastStateFactory : IInteractionStateFactory
    {
        private readonly IObjectResolver _resolver;

        public RaycastStateFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public IInteractionState Create(string value)
        {
            return value switch
            {
                RaycastStateConstants.Default => DefaultRaycastState(),
                RaycastStateConstants.Units => UnitsRaycastState(),
                RaycastStateConstants.Grid => GridRaycastState(),
                _ => null
            };
        }

        private IInteractionState DefaultRaycastState()
        {
            var unitActionService = _resolver.Resolve<IUnitActionService>();
            return new DefaultInteractionState(unitActionService);
        }

        private IInteractionState UnitsRaycastState()
        {
            var unitActionService = _resolver.Resolve<IUnitActionService>();
            return new UnitsInteractionState(unitActionService);
        }

        private IInteractionState GridRaycastState()
        {
            var unitActionService = _resolver.Resolve<IUnitActionService>();
            return new GridInteractionState(unitActionService);
        }
    }
}
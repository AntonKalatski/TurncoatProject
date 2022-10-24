using Services.RaycastService.Entities.States;
using Services.RaycastService.Interfaces;
using Services.Realisations.UnitService;
using VContainer;
using VContainer.Unity;

namespace Services.RaycastService.Entities.Factory
{
    public class RaycastStateFactory : IInteractionStateFactory, IInitializable
    {
        private readonly IObjectResolver _resolver;

        public RaycastStateFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public void Initialize()
        {
            
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
            var unitService = _resolver.Resolve<IUnitService>();
            return new DefaultInteractionState(unitService);
        }

        private IInteractionState UnitsRaycastState()
        {
            var unitService = _resolver.Resolve<IUnitService>();
            return new UnitSelectionState(unitService);
        }

        private IInteractionState GridRaycastState()
        {
            var unitService = _resolver.Resolve<IUnitService>();
            return new UnitMoveState(unitService);
        }
    }
}
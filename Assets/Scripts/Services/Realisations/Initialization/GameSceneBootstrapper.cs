using Services.GameLevelService;
using Services.LevelGrid;
using Services.RaycastService.Interfaces;
using Services.Realisations.UnitService;
using VContainer.Unity;

namespace Services.Realisations.Initialization
{
    public class GameSceneBootstrapper : IStartable
    {
        private readonly ILevelGridService _levelGridService;
        private readonly IRaycastService _raycastService;
        private readonly IInteractionManager _interactionManager;
        private readonly ILevelService _levelService;
        private readonly IUnitService _unitService;

        public GameSceneBootstrapper(ILevelGridService levelGridService, IRaycastService raycastService,
            IInteractionManager interactionManager, IUnitService unitService, ILevelService levelService)
        {
            _levelGridService = levelGridService;
            _raycastService = raycastService;
            _interactionManager = interactionManager;
            _unitService = unitService;
            _levelService = levelService;
        }

        public void Start()
        {
            _raycastService.Initialize();
            _interactionManager.Initialize();
            _levelGridService.CreateLevelGrid(); //todo Important - grid and level creates first 
            _unitService.CreateLevelUnits(_levelService.GetLevelConfig());

            //todo another responsibility 
        }
    }
}
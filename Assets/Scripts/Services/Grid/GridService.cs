using Services.GameInputProvider.Entities;
using Services.GameInputProvider.Interfaces;
using Services.RaycastService.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Services.Grid
{
    public class GridService : IGridService, IInitializable, IInputListener
    {
        private readonly GridConfig _config;
        private readonly IInputService _inputService;
        private readonly IRaycastService _raycastService;
        private Grid _grid;

        public GridService(GridConfig config, IInputService inputService, IRaycastService raycastService)
        {
            _config = config;
            _inputService = inputService;
            _raycastService = raycastService;
        }

        public void Initialize()
        {
            _inputService.AddInputListener(this);
            _grid = new Grid(_config.X, _config.Z, _config.CellSize);
            _grid.CreateDebugObjects(_config.Prefab);
        }

        public void OnMouseButtonDownHandler(InputArgs args)
        {
            if (_raycastService.Raycast(args, out RaycastHit hit))
            {
                Debug.Log(_grid.GetGridPosition(hit.point));
            }
        }
    }
}
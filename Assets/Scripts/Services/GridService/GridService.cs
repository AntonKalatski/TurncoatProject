using UnityEngine;
using Services.GameInputProvider.Entities;
using Services.GameInputProvider.Interfaces;
using Services.RaycastService.Interfaces;

namespace Services.GridService
{
    public class GridService : IGridService, IPointerDownListener
    {
        private readonly GridConfig _config;
        private readonly IRaycastService _raycastService;
        public Grid Grid { get; private set; }

        public GridService(GridConfig config, IInputService inputService, IRaycastService raycastService)
        {
            _config = config;
            _raycastService = raycastService;
            inputService.AddPointerDownListener(this);
        }

        public Grid CreateGrid()
        {
            Grid = new Grid(_config.X, _config.Z, _config.CellSize);
            Grid.CreateDebugObjects(_config.Prefab);
            return Grid;
        }

        public bool TryGetGridCell(Vector3 position, out GridCell cell)
        {
            return Grid.TryGetGridCell(position, out cell);
        }

        public bool TryGetRandomGridCell(out GridCell cell)
        {
            cell = Grid.GetRandomGridCell();
            return !ReferenceEquals(cell, null);
        }

        public Vector3 GetWorldPosition(GridPosition gridPosition)
        {
            return Grid.GetWorldPosition(gridPosition);
        }

        public GridPosition GetGridPosition(Vector3 position)
        {
            return Grid.GetGridPosition(position);
        }

        public void OnPointerDownHandler(InputArgs args)
        {
            if (_raycastService.Raycast(args, out RaycastHit hit))
            {
                Debug.Log(Grid.GetGridPosition(hit.point).ToString());
            }
        }
    }
}
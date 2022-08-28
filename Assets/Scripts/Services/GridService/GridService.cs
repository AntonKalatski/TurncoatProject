using Services.GameInputProvider.Entities;
using Services.GameInputProvider.Interfaces;
using Services.RaycastService.Interfaces;
using Services.Realisations.Units;
using UnityEngine;

namespace Services.GridService
{
    //todo only creates grid but stores a reference
    //todo this service contains rules 
    public class GridService : IGridService, IInputListener
    {
        private readonly GridConfig _config;
        private readonly IRaycastService _raycastService;
        private Grid Grid { get; set; }

        public GridService(GridConfig config, IInputService inputService, IRaycastService raycastService)
        {
            _config = config;
            _raycastService = raycastService;
            inputService.AddInputListener(this);
        }

        public Grid CreateGrid()
        {
            Grid = new Grid(_config.X, _config.Z, _config.CellSize);
            Grid.CreateDebugObjects(_config.Prefab);
            return Grid;
        }

        public void OnMouseButtonDownHandler(InputArgs args)
        {
            if (_raycastService.Raycast(args, out RaycastHit hit))
            {
                Debug.Log(Grid.GetGridPosition(hit.point));
            }
        }

        // public GridCell GetGridCell(Vector3 pos)
        // {
            //     var gridPosition = Grid.GetGridPosition(pos);
        //     return Grid.GetGridCell(gridPosition);
        // }
        //
        // public void SetGridCell(Unit selectedUnit, GridCell cell)
        // {
        //     cell.SetUnit(selectedUnit);
        // }
    }
}
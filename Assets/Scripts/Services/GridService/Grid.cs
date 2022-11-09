using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.GridService
{
    public class Grid
    {
        private readonly int _width;
        private readonly int _height;
        private readonly float _cellSize;
        private readonly Transform _gridRoot;
        private readonly GridCell[,] _gridCellsArray;
        private readonly Dictionary<GridPosition, GridCell> _gridCellsMap;
        public Dictionary<GridPosition, GridCell> GridCellsMap => _gridCellsMap;

        public Grid(int width, int height, float cellSize)
        {
            _width = width;
            _height = height;
            _cellSize = cellSize;
            _gridCellsArray = new GridCell[_width, _height];
            _gridCellsMap = new Dictionary<GridPosition, GridCell>(_width * _height);
            _gridRoot = new GameObject("Grid Root").transform;

            for (var x = 0; x < _width; x++)
            {
                for (var z = 0; z < _height; z++)
                {
                    var gridPosition = new GridPosition(x, z);
                    var gridCell = new GridCell(this, gridPosition, GetWorldPosition(gridPosition));
                    _gridCellsArray[x, z] = gridCell;
                    _gridCellsMap.Add(gridPosition, gridCell);
                }
            }
        }


        public bool TryGetGridCell(Vector3 hitPosition, out GridCell gridCell) =>
            _gridCellsMap.TryGetValue(GetGridPosition(hitPosition), out gridCell);

        public GridPosition GetGridPosition(Vector3 pos)
        {
            var xPos = Mathf.RoundToInt(pos.x / _cellSize);
            var zPos = Mathf.RoundToInt(pos.z / _cellSize);

            return new GridPosition(xPos, zPos);
        }

        public Vector3 GetWorldPosition(GridPosition pos)
        {
            return new Vector3(pos.X, 0, pos.Z) * _cellSize;
        }

        public void CreateDebugObjects(Transform transform)
        {
            for (var x = 0; x < _width; x++)
            {
                for (var z = 0; z < _height; z++)
                {
                    var pos = new GridPosition(x, z);
                    var debugCell =
                        Object.Instantiate(transform, GetWorldPosition(pos), Quaternion.identity, _gridRoot);
                    if (debugCell.TryGetComponent(out GridDebugObject debugObject))
                    {
                        debugObject.InitializeGridCell(GetGridCell(pos));
                    }
                }
            }
        }

        private GridCell GetGridCell(GridPosition pos) => _gridCellsArray[pos.X, pos.Z];

        public GridCell GetRandomGridCell() => _gridCellsMap.Values.ToList()[Random.Range(0, _gridCellsMap.Count)];
    }
}
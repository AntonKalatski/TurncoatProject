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
        private readonly GridCell[][] _gridCellsArray;
        private readonly List<GridCell> _gridCellsList;

        public Grid(int width, int height, float cellSize)
        {
            _width = width;
            _height = height;
            _cellSize = cellSize;
            _gridCellsList = new List<GridCell>();
            _gridCellsArray = new GridCell[_width][];
            _gridRoot = new GameObject("Grid Root").transform;

            for (var x = 0; x < _width; x++)
            {
                _gridCellsArray[x] = new GridCell[_height];
                for (var z = 0; z < _height; z++)
                {
                    var gridCell = new GridCell(this, new GridPosition(x, z));
                    _gridCellsArray[x][z] = gridCell;
                    _gridCellsList.Add(gridCell);
                }
            }

            _gridCellsList = _gridCellsArray.SelectMany(cell => cell).ToList();
        }


        public bool TryGetGridCell(Vector3 hitPosition, out GridCell gridCell)
        {
            var gridPosition = GetGridPosition(hitPosition);
            gridCell = _gridCellsList.FirstOrDefault(cell => cell.Position.Equals(gridPosition));
            return !ReferenceEquals(gridCell, null);
        }

        public GridPosition GetGridPosition(Vector3 pos)
        {
            var xPos = Mathf.RoundToInt(pos.x / _cellSize);
            var zPos = Mathf.RoundToInt(pos.z / _cellSize);

            return new GridPosition(xPos, zPos);
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

        private GridCell GetGridCell(GridPosition pos)
        {
            return _gridCellsArray[pos.X][pos.Z];
        }

        private Vector3 GetWorldPosition(GridPosition pos)
        {
            return new Vector3(pos.X, 0, pos.Z) * _cellSize;
        }

        public GridCell GetRandomGridCell()
        {
            var random = UnityEngine.Random.Range(0, _gridCellsList.Count);
            return _gridCellsList[random];
        }
    }
}
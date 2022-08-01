using UnityEngine;

namespace Services.Grid
{
    public class Grid
    {
        private readonly int _width;
        private readonly int _height;
        private readonly float _cellSize;
        private GridCell[,] _gridCellsArray;

        public Grid(int width, int height, float cellSize)
        {
            _width = width;
            _height = height;
            _cellSize = cellSize;
            _gridCellsArray = new GridCell[width, height];
            for (int x = 0; x < _width; x++)
            {
                for (int z = 0; z < _height; z++)
                {
                    GridPosition pos = new GridPosition(x, z);
                    _gridCellsArray[x,z] = new GridCell(this, pos);
                }
            }
        }

        public Vector3 GetWorldPosition(int x, int z)
        {
            return new Vector3(x, 0, z) * _cellSize;
        }

        public GridPosition GetGridPosition(Vector3 pos)
        {
            return new GridPosition(
                Mathf.RoundToInt(pos.x / _cellSize),
                Mathf.RoundToInt(pos.z / _cellSize)
            );
        }

        public void CreateDebugObjects(Transform transform)
        {
            for (var x = 0; x < _width; x++)
            {
                for (var z = 0; z < _width; z++)
                {
                    Object.Instantiate(transform, GetWorldPosition(x, z), Quaternion.identity);
                }
            }
        }
    }
}
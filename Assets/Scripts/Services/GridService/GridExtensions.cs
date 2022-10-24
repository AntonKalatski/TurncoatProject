using UnityEngine;

namespace Services.GridService
{
    public static class GridExtensions
    {
        public static Vector3 ToVector3(this GridPosition gridPosition) => new(gridPosition.X, 0, gridPosition.Z);

        public static GridPosition ToGridPosition(this Vector3 worldPosition) => new(Mathf.RoundToInt(worldPosition.x),
            Mathf.RoundToInt(worldPosition.z));
    }
}
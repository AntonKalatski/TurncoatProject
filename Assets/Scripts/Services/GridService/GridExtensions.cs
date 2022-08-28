using UnityEngine;

namespace Services.GridService
{
    public static class GridExtensions
    {
        public static Vector3 ToVector3(this GridPosition gridPosition) => new Vector3(gridPosition.X,0,gridPosition.Z);
    }
}
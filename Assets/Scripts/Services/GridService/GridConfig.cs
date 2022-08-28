using UnityEngine;

namespace Services.GridService
{
    [CreateAssetMenu(fileName = nameof(GridConfig), menuName = "Configs/Grid/" + nameof(GridConfig))]
    public class GridConfig : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int x = 10;
        [SerializeField] private int z = 10;
        [SerializeField, Range(1f, 5f)] private float cellSize = 1f;

        public int X => x;
        public int Z => z;

        public float CellSize => cellSize;
        public Transform Prefab => prefab.transform;
    }
}
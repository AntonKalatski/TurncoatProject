using UnityEngine;

namespace Services.PointerService
{
    [CreateAssetMenu(fileName = nameof(PointerServiceConfig),
        menuName = "Configs/Pointer/" + nameof(PointerServiceConfig), order = 0)]
    public class PointerServiceConfig : ScriptableObject
    {
        [SerializeField] private GameObject prefab;

        public GameObject PointerPrefab => prefab;
    }
}
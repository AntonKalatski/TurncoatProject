using System.Collections.Generic;
using Services.Realisations.Units;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Services.Realisations.UnitService
{
    [CreateAssetMenu(fileName = nameof(UnitConfig), menuName = "Configs/Units/" + nameof(UnitConfig))]
    public class UnitConfig : SerializedScriptableObject, IUnitConfig
    {
        [OdinSerialize] private Dictionary<UnitType, Unit> _unitPrefabsMap = new Dictionary<UnitType, Unit>();
        [SerializeField] private string[] _unitNames = new[] { "Bob", "John", "Rapunzel", "George", "Alex", "Mary" };

        public bool TryGetUnit(UnitType type, out Unit unit) => _unitPrefabsMap.TryGetValue(type, out unit);

        public string GetRandomUnitName() => _unitNames[Random.Range(0, _unitNames.Length - 1)];
    }
}
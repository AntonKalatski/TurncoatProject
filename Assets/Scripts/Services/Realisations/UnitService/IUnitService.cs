using System.Collections.Generic;
using Services.GameLevelService;
using Services.Realisations.Units;
using UnityEngine;

namespace Services.Realisations.UnitService
{
    public interface IUnitService
    {
        HashSet<Unit> Units { get; }
        void CreateLevelUnits(ILevelConfig levelConfig);
        void HandleUnitSelection(ref RaycastHit hit);
        void HandleUnitDeselection();
        void HandleUnitMove(ref RaycastHit hit);
    }
}
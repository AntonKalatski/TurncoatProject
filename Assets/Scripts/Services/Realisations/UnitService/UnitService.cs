using System.Collections.Generic;
using Services.GameLevelService;
using Services.GridService;
using Services.LevelGrid;
using Services.Realisations.Units;
using UnityEngine;
using VContainer.Unity;

namespace Services.Realisations.UnitService
{
    public class UnitService : IUnitService, ITickable
    {
        private readonly IUnitData _unitData;
        private readonly IUnitFactory _unitFactory;
        private readonly ILevelGridService _levelGrid;

        private Unit ActiveUnit { get; set; }
        public HashSet<Unit> Units { get; } = new HashSet<Unit>();

        public UnitService(IUnitData unitData, IUnitFactory unitFactory, ILevelGridService levelGrid)
        {
            _unitData = unitData;
            _unitFactory = unitFactory;
            _levelGrid = levelGrid;
        }

        public void CreateLevelUnits(ILevelConfig levelConfig)
        {
            foreach (var unitType in levelConfig.LevelUnits.Keys)
            {
                for (var i = 0; i < levelConfig.LevelUnits[unitType]; i++)
                {
                    InitializeUnit(_unitFactory.CreateUnit(unitType));
                }
            }
        }

        //for test only!!
        public void Tick()
        {
            if (ReferenceEquals(ActiveUnit, null)) return;
            _levelGrid.TrySetUnitOnGridCell(ActiveUnit, ActiveUnit.WorldPosition, out var pos);
            //todo track position
        }

        private void InitializeUnit(Unit unit)
        {
            if (!Units.Add(unit))
                return;

            var unitTransform = unit.transform;
            var gridPos = _levelGrid.GetRandomGridCell().Position.ToVector3();
            _levelGrid.TrySetUnitOnGridCell(unit, gridPos, out var unitPos);
            unitTransform.position = unitPos;
            unitTransform.rotation = Quaternion.identity;
            unit.OnUnitMoving += UnitMovingHandler;
            //todo rework to single responsibility
            Debug.Log("Successfully created unit");
        }

        private void UnitMovingHandler(Unit activeUnit)
        {
            ActiveUnit = activeUnit.IsMoving ? activeUnit : null;
        }
    }
}
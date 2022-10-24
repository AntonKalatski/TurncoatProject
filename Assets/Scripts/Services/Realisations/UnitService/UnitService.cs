using System.Collections.Generic;
using Services.GameLevelService;
using Services.GridService;
using Services.LevelGrid;
using Services.Realisations.Units;
using UnityEngine;

namespace Services.Realisations.UnitService
{
    public class UnitService : IUnitService
    {
        private readonly IUnitData _unitData;
        private readonly IUnitConfig _config;
        private readonly IUnitFactory _unitFactory;
        private readonly ILevelGridService _levelGrid;
        private Unit ActiveUnit { get; set; }
        public HashSet<Unit> Units { get; } = new HashSet<Unit>();

        public UnitService(IUnitData unitData,
            IUnitFactory unitFactory,
            ILevelGridService levelGrid,
            IUnitConfig config)
        {
            _unitData = unitData;
            _unitFactory = unitFactory;
            _levelGrid = levelGrid;
            _config = config;
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

        public void HandleUnitSelection(ref RaycastHit hit)
        {
            if (hit.transform.TryGetComponent<Unit>(out var unit))
                SetSelectedUnit(unit);
        }

        public void HandleUnitDeselection()
        {
            ActiveUnit?.Deselect();
            ActiveUnit = null;
        }

        public void HandleUnitMove(ref RaycastHit hit)
        {
            if (ReferenceEquals(ActiveUnit, null)) return;
            if (!_levelGrid.TryGetGridCellAtPoint(hit.point, out var cell)) return;
            ActiveUnit.OnUnitStartMoving += UnitStartMovingHandler;
            ActiveUnit.OnUnitIsMoving += UnitMovingHandler;
            ActiveUnit.OnUnitStopMoving += UnitStopMovingHandler;
            ActiveUnit.Move(cell.WorldPosition);
        }

        private void UnitMovingHandler(Unit unit)
        {
            GridPosition currentPosition = _levelGrid.GetGridPosition(ActiveUnit.CurrentPosition);
            GridPosition previousPosition = _levelGrid.GetGridPosition(ActiveUnit.PreviousPosition);

            if (currentPosition == previousPosition)
            {
                return;
            }

            if (!_levelGrid.TrySetUnitOnGridCell(ActiveUnit, out var cell))
            {
                return;
            }

            if (!_levelGrid.TryClearGridCellAtPoint(ActiveUnit.PreviousPosition, out var previousCell))
            {
                return;
            }

            ActiveUnit.SetPreviousPosition(_levelGrid.GetWorldPosition(currentPosition));
        }

        private void SetSelectedUnit(Unit unit)
        {
            if (ReferenceEquals(ActiveUnit, unit))
            {
                return;
            }

            ActiveUnit?.Deselect();
            ActiveUnit = unit;
            ActiveUnit.SetSelected();
        }

        private void InitializeUnit(Unit unit)
        {
            if (!Units.Add(unit))
                return;

            unit.UnitName = _config.GetRandomUnitName();

            if (_levelGrid.TryGetRandomGridCell(out GridCell gridCell))
                unit.transform.SetPositionAndRotation(gridCell.WorldPosition, Quaternion.identity);
            _levelGrid.TrySetUnitOnGridCell(unit, gridCell);
        }

        private void UnitStartMovingHandler(Unit unit)
        {
            Debug.Log("KALATSKI__Unit START moving");
            if (!_levelGrid.TryClearGridCellAtPoint(ActiveUnit.CurrentPosition, out var gridCell)) return;
            ActiveUnit.SetPreviousPosition(gridCell.WorldPosition);
        }

        private void UnitStopMovingHandler(Unit unit)
        {
            Debug.Log("KALATSKI__Unit STOP moving");
            if (_levelGrid.TrySetUnitOnGridCell(ActiveUnit, out var gridCell))
            {
                ActiveUnit.SetPreviousPosition(gridCell.WorldPosition);
            }

            ActiveUnit.OnUnitStartMoving -= UnitStartMovingHandler;
            ActiveUnit.OnUnitIsMoving -= UnitMovingHandler;
            ActiveUnit.OnUnitStopMoving -= UnitStopMovingHandler;
        }
    }
}
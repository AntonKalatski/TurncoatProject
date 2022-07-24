using System;
using RayCaster;
using Units;
using UnityEngine;

namespace Services.Realisations.UnitActions
{
    public class UnitActionService : MonoBehaviour
    {
        public event EventHandler OnSelectedUnitChange;
        
        [SerializeField] private Unit selectedUnit;
        [SerializeField] private MouseRaycaster raycaster;
        [SerializeField] private LayerMask layerMask;
        private Camera _camera;
        public static UnitActionService Instance { get; private set; }


        private void Awake()
        {
            _camera = Camera.main;
            if (Instance != null)
            {
                Debug.LogError("There's more than one Unit Action system!" + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(TryHandleUnitSelection()) return;
                if (raycaster.TryGetPosition(out Vector3 position))
                    selectedUnit.Move(position);
            }
        }

        public Unit GetSelectedUnit()
        {
            return selectedUnit;
        }

        private bool TryHandleUnitSelection()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask)) return false;
            if (!raycastHit.transform.TryGetComponent<Unit>(out var unit)) return false;
            SetSelectedUnit(unit);
            return true;
        }

        private void SetSelectedUnit(Unit unit)
        {
            selectedUnit = unit;
            OnSelectedUnitChange?.Invoke(this,EventArgs.Empty);
        }
    }
}
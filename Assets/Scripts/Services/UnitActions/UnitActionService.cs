using System;
using RayCaster;
using UnityEngine;
using Units;

namespace Services.UnitActions
{
    public class UnitActionService : MonoBehaviour
    {
        [SerializeField] private Unit selectedUnit;
        [SerializeField] private MouseRaycaster raycaster;
        [SerializeField] private LayerMask layerMask;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
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

        private bool TryHandleUnitSelection()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask)) return false;
            if (!raycastHit.transform.TryGetComponent<Unit>(out var unit)) return false;
            selectedUnit = unit;
            return true;
        }
    }
}
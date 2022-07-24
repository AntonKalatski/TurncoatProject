using System;
using Services.Realisations.UnitActions;
using UnityEngine;

namespace Units
{
    public class UnitSelectedVisuals : MonoBehaviour
    {
        [SerializeField] private Unit unit;
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer ??= GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            UnitActionService.Instance.OnSelectedUnitChange += OnUnitSelectedHandler;
            UpdateVisual();
        }

        private void OnUnitSelectedHandler(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            _meshRenderer.enabled = ReferenceEquals(UnitActionService.Instance.GetSelectedUnit(), unit);
        }

        private void OnDestroy()
        {
            UnitActionService.Instance.OnSelectedUnitChange -= OnUnitSelectedHandler;
        }
    }
}
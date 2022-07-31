using UnityEngine;

namespace Services.Realisations.Units
{
    public class UnitSelectedVisuals : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer ??= GetComponent<MeshRenderer>();
        }
        
        public void SetVisualsEnabled(bool isEnabled)
        {
            _meshRenderer.enabled = isEnabled;
        }
    }
}
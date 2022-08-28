using UnityEngine;

namespace Services.Realisations.Units
{
    public class UnitSelectedVisuals : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;

        public void SetVisualsEnabled(bool isEnabled)
        {
            meshRenderer.enabled = isEnabled;
        }
    }
}
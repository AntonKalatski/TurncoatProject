using TMPro;
using UnityEngine;

namespace Services.GridService
{
    public class GridDebugObject : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private GridCell _cell;

        public void InitializeGridCell(GridCell cell)
        {
            _cell = cell;
            _cell.OnDataChanged += UpdateText;
            UpdateText();
        }

        private void UpdateText()
        {
            text.text = _cell.ToString();
        }
    }
}
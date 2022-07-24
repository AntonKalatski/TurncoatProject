using UnityEngine;

namespace Services.GameInputProvider.Entities
{
    [CreateAssetMenu(fileName = nameof(InputConfig), menuName = "Configs/GameInput/" + nameof(InputConfig), order = 0)]
    public class InputConfig : ScriptableObject, IInputConfig
    {
        [SerializeField] private string testString = nameof(InputConfig);

        public string GetInfo => testString;
    }
}
using UnityEngine;

namespace Configs.Test
{
    [CreateAssetMenu(fileName = nameof(TestConfig), menuName = "Configs/Test", order = 0)]
    public class TestConfig : ScriptableObject
    {
        [SerializeField] private float _someFloat;
        [SerializeField] private string _someString;
        [SerializeField] private SomeStruct _someStruct;

        public float SomeFloat => _someFloat;

        public string SomeString => _someString;

        public SomeStruct SomeStruct => _someStruct;
    }

    [System.Serializable]
    public struct SomeStruct
    {
       public string testString;
       public int testInt;
       public override string ToString() => $"Test string {testString}, test int {testInt}";
    }
}
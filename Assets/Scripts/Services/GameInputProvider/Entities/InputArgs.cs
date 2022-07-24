using UnityEngine;

namespace Services.GameInputProvider.Entities
{
    public record InputArgs
    {
        public Vector2 Pointer { get; init; }
        public Vector2 PrevPointer { get; init; }
        public Vector2 Delta { get; init; }

        public InputArgs(Vector2 pointer, Vector2 previousPointer)
        {
            Pointer = pointer;
            PrevPointer = previousPointer;
            Delta = pointer - previousPointer;
        }
    }
}
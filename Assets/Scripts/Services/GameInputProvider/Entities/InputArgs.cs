using UnityEngine;

namespace Services.GameInputProvider.Entities
{
    public struct InputArgs
    {
        public Vector2 Pointer { get; }
        public Vector2 PrevPointer { get; }
        public Vector2 Delta { get; }
        public int PointerId { get; }

        public InputArgs(Vector2 pointer, Vector2 previousPointer, int pointerId = default)
        {
            Pointer = pointer;
            PrevPointer = previousPointer;
            Delta = pointer - previousPointer;
            PointerId = pointerId;
        }
    }
}
using UnityEngine;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Transform myTransform;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField, Range(0, 0.25f)] private float minDistance = 0.05f;
        private Vector3 _targetPosition;
        private bool _canMove;

        private void Awake()
        {
            if (TryGetComponent<Transform>(out var trans))
                myTransform = transform;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Move(GenerateRandomValue());
            }

            if (_canMove)
            {
                MovementProcess();
            }
        }

        private Vector3 GenerateRandomValue()
        {
            float x = Random.Range(-5, 5);
            float z = Random.Range(-5, 5);
            return new Vector3(x, 0, z);
        }

        private void MovementProcess()
        {
            var distance = _targetPosition - myTransform.position;
            if (distance.sqrMagnitude > minDistance)
            {
                myTransform.position += distance.normalized * (Time.deltaTime * moveSpeed);
            }
            else
            {
                _canMove = false;
            }
        }

        private void Move(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
            _canMove = true;
        }
    }
}
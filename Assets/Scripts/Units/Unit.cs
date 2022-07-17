using System;
using RayCaster;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Transform myTransform;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField, Range(0, 0.25f)] private float minDistance = 0.05f;
        private Vector3 _targetPosition;
        private bool _canMove;
        private MouseRaycaster _mouseRaycaster;

        private void Awake()
        {
            if (TryGetComponent<Transform>(out var trans))
                myTransform = transform;
        }

        private void Start()
        {
            _mouseRaycaster = MouseRaycaster.Instance;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_mouseRaycaster.TryGetPosition(out Vector3 position))
                    Move(position);
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
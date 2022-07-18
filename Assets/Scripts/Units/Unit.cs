using RayCaster;
using UnityEngine;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Animator unitAnimator;
        [SerializeField] private Transform myTransform;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField, Range(0, 0.25f)] private float minDistance = 0.05f;
        private MouseRaycaster _mouseRaycaster;
        private Vector3 _targetPosition;
        private bool _isMoving;
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        private bool CanMove
        {
            get => _isMoving;
            set
            {
                _isMoving = value;
                unitAnimator.SetBool(IsWalking, value);
            }
        }
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
            if (!CanMove) return;
            MovementProcess();
            RotationProcess();
        }
        public void Move(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
            CanMove = true;
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
                CanMove = false;
            }
        }

        private void RotationProcess()
        {
            Vector3 relativePos = _targetPosition - myTransform.position;
            Quaternion currentRot = myTransform.localRotation;
            Quaternion futureRotation = Quaternion.LookRotation(relativePos);
            transform.localRotation = Quaternion.Slerp(currentRot, futureRotation,Time.deltaTime * moveSpeed);
        }
    }
}
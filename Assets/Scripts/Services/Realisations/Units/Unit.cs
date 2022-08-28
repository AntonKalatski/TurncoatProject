using System;
using Services.RaycastService.Entities;
using UnityEngine;

namespace Services.Realisations.Units
{
    //todo huge trash class - need to rework
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Animator unitAnimator;
        [SerializeField] private Transform myTransform;
        [SerializeField] private UnitSelectedVisuals visuals;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField, Range(0, 0.25f)] private float minDistance = 0.05f;
        private MouseRaycaster _mouseRaycaster;
        private Vector3 _targetPosition;
        private bool _isMoving;
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        public event Action<Unit> OnUnitMoving;
        public Vector3 WorldPosition => transform.position;


        public bool IsMoving
        {
            get => _isMoving;
            private set
            {
                _isMoving = value;
                OnUnitMoving?.Invoke(this);
                unitAnimator.SetBool(IsWalking, value);
            }
        }

        private void Awake()
        {
            visuals.SetVisualsEnabled(false);
            myTransform = transform;
        }

        private void Start()
        {
            _mouseRaycaster = MouseRaycaster.Instance;
        }

        private void Update()
        {
            if (!IsMoving) return;
            MovementProcess();
            RotationProcess();
        }

        public void Move(Vector3 position)
        {
            _targetPosition = position;
            IsMoving = true;
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
                IsMoving = false;
            }
        }

        private void RotationProcess()
        {
            Vector3 relativePos = _targetPosition - myTransform.position;
            Quaternion currentRot = myTransform.localRotation;
            Quaternion futureRotation = Quaternion.LookRotation(relativePos);
            transform.localRotation = Quaternion.Slerp(currentRot, futureRotation, Time.deltaTime * moveSpeed);
        }

        public void Deselect()
        {
            visuals.SetVisualsEnabled(false);
        }

        public void SetSelected()
        {
            visuals.SetVisualsEnabled(true);
        }

        public override string ToString()
        {
            return $"Unit_Name";
        }
    }
}
using System;
using Cinemachine;
using Services.CameraService.Entities;
using Services.CameraService.Interfaces;
using Services.GameInputProvider.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Game.Controllers.GameCamera
{
    public class CameraController : IKeyboardInputListener, IStartable, IDisposable
    {
        private CinemachineVirtualCamera _cinemachineVirtualCamera;
        private CinemachineTransposer _transposer;
        private const float MinFollowYOffset = 2f;
        private const float MaxFollowYOffset = 8f;
        private Vector3 _targetFollowOffset;
        private IInputService _inputService;
        private ICameraService _cameraService;
        private Transform _rootObject;
        private Transform _cameraFollowPoint;

        public CameraController(IInputService inputService, ICameraService cameraService)
        {
            _inputService = inputService;
            _cameraService = cameraService;
        }

        public void Start()
        {
            _inputService.AddKeyboardListener(this);
            if (_cameraService.TryGetCameraProvider(CameraId.CinemachineCamera,
                    out ICameraProvider<CinemachineVirtualCamera> cameraProvider))
            {
                _rootObject = new GameObject("CameraFollowPointRoot").transform;
                _cameraFollowPoint = new GameObject("CameraFollowPoint").transform;
                _cameraFollowPoint.SetParent(_rootObject);
                cameraProvider.Camera.Follow = _cameraFollowPoint;
                cameraProvider.Camera.LookAt = _cameraFollowPoint;
                _transposer = cameraProvider.Camera.GetCinemachineComponent<CinemachineTransposer>();
            }

            _targetFollowOffset = _transposer.m_FollowOffset;
        }

        public void Dispose()
        {
            _inputService.RemoveKeyboardListener(this);
        }

        public void OnKeyDown(KeyCode key)
        {
            HandleMovement(key);
            HandleRotation(key);
            HandleZoom();
        }

        private void HandleMovement(KeyCode keyCode)
        {
            var inputMoveDir = new Vector3(0, 0, 0);

            switch (keyCode)
            {
                case KeyCode.W:
                    inputMoveDir.z = +1f;
                    break;
                case KeyCode.S:
                    inputMoveDir.z = -1f;
                    break;
                case KeyCode.A:
                    inputMoveDir.x = -1f;
                    break;
                case KeyCode.D:
                    inputMoveDir.x = +1f;
                    break;
            }

            Vector3 moveVector =
                _cameraFollowPoint.forward * inputMoveDir.z + _cameraFollowPoint.right * inputMoveDir.x;
            float moveSpeed = 5f; //make variable from config
            _cameraFollowPoint.position += moveVector * (moveSpeed * Time.deltaTime);
        }

        private void HandleRotation(KeyCode keyCode)
        {
            Vector3 rotationVector = new Vector3(0, 0, 0);

            rotationVector.y = keyCode switch
            {
                KeyCode.Q => +1f,
                KeyCode.E => -1f,
                _ => rotationVector.y
            };

            var rotationSpeed = 50f; //make variable from config
            _cameraFollowPoint.eulerAngles += rotationVector * (rotationSpeed * Time.deltaTime);
        }

        private void HandleZoom()//TODO mouse wheel listener
        {
            float zoomAmount = 1f; //make variable from config
            float zoomSpeed = 5f; //make variable from config
            _targetFollowOffset = _transposer.m_FollowOffset;

            if (Input.mouseScrollDelta.y > 0)
                _targetFollowOffset.y -= zoomAmount;
            if (Input.mouseScrollDelta.y < 0)
                _targetFollowOffset.y += zoomAmount;

            _targetFollowOffset.y = Mathf.Clamp(_targetFollowOffset.y, MinFollowYOffset, MaxFollowYOffset);
            _transposer.m_FollowOffset =
                Vector3.Lerp(_transposer.m_FollowOffset, _targetFollowOffset, Time.deltaTime * zoomSpeed);
        }
    }
}